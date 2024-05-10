using System.Net;
using System.Text.Json;
using PokemonsAPI.Core.Entities;
using PokemonsAPI.Core.Interfaces;
using PokemonsAPI.Core.Models.PokemonApiModels;
using Ability = PokemonsAPI.Core.Entities.Ability;
using Move = PokemonsAPI.Core.Entities.Move;
using Stat = PokemonsAPI.Core.Entities.Stat;
using Type = PokemonsAPI.Core.Entities.Type;

namespace PokemonsAPI.Core;

public class PokemonDbContextSeeder(IPokemonDbContext context) : IPokemonDbContextSeeder
{
    private readonly HttpClient _httpClient = new();
    private static readonly Uri PokemonApiUrl = new("https://pokeapi.co/api/v2/pokemon?limit=10000&offset=0");

    public async Task SeedAsync(CancellationToken cancellationToken = default)
    {
        var info = await GetFromApi<PokemonsInfo>(PokemonApiUrl, cancellationToken);

        var pokemonsNamesFromDb = context.Pokemons.Select(pokemon => pokemon.Name);

        var newPokemons = info.Pokemons.Where(x =>
            !pokemonsNamesFromDb.Contains(x.PokemonName));

        foreach (var pokemonInfo in newPokemons)
        {
            var pokemon = await GetFromApi<PokemonFromApi>(pokemonInfo.PokemonUrl, cancellationToken)
                .ConfigureAwait(false);

            var dbPokemon = MapFromPokemonFromApi(pokemon);

            await context.Pokemons.AddAsync(dbPokemon, cancellationToken).ConfigureAwait(false);
        }

        await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    private async Task<string> SendGetRequestAsync(Uri requestUri,
        CancellationToken cancellationToken = default)
    {
        var message = new HttpRequestMessage();
        message.RequestUri = requestUri;
        message.Method = HttpMethod.Get;

        var httpResponse = await _httpClient.SendAsync(message, cancellationToken);

        if (httpResponse.StatusCode != HttpStatusCode.OK)
            throw new HttpRequestException(
                $"{(int)httpResponse.StatusCode} by {requestUri} in {nameof(SendGetRequestAsync)}");

        return await httpResponse.Content.ReadAsStringAsync(cancellationToken);
    }

    private async Task<T> GetFromApi<T>(Uri requestUri, CancellationToken cancellationToken = default)
    {
        var resultJson = await SendGetRequestAsync(requestUri, cancellationToken);

        var result = JsonSerializer.Deserialize<T>(resultJson) ?? throw new NullReferenceException(
            $"Null {nameof(PokemonsInfo)} was returned from {requestUri} in {nameof(GetFromApi)} service");

        return result;
    }

    private Pokemon MapFromPokemonFromApi(PokemonFromApi pokemon)
    {
        var result = new Pokemon
        {
            Id = pokemon.Id,
            Name = pokemon.Name,
            ImageUrl = pokemon.Sprites.Other.Home.Front_Default
        };

        result.Breeding = new Breeding
        {
            Id = Guid.NewGuid(),
            PokemonId = result.Id,
            Weight = pokemon.Weight,
            Height = pokemon.Height
        };

        result.Abilities = pokemon.Abilities.Select(x =>
            new Ability
            {
                Id = Guid.NewGuid(),
                PokemonId = result.Id,
                AbilityName = x.AbilityValue.AbilityName
            }).ToList();
        
        result.Types = pokemon.Types.Select(x =>
            new Type
            {
                Id = Guid.NewGuid(),
                PokemonId = result.Id,
                TypeName = x.TypeValue.TypeName
            }
        ).ToList();

        result.Moves = pokemon.Moves.Select(x =>
            new Move
            {
                Id = Guid.NewGuid(),
                PokemonId = result.Id,
                MoveName = x.MoveValue.MoveName,
            }
        ).ToList();

        result.Stats = pokemon.Stats.Select(x =>
            new Stat
            {
                Id = Guid.NewGuid(),
                PokemonId = result.Id,
                StatValue = x.BaseStat,
                StatName = x.StatValue.StatName
            }
        ).ToList();

        return result;
    }
}