using Microsoft.EntityFrameworkCore;
using PokemonsAPI.Core.Entities;
using PokemonsAPI.Core.Interfaces;
using PokemonsAPI.Core.Models;

namespace PokemonsAPI.Core.Services;

/// <summary>
/// 
/// </summary>
public class PokemonApiService(IPokemonDbContext pokemonDbContext) : IPokemonApiService
{
    /// <inheritdoc />
    public async Task<List<PokemonResponseDto>> GetByFilterAsync(string filter = "",
        CancellationToken cancellationToken = default, int limit = 20, int offset = 0)
    {
        var filteredPokemons = await pokemonDbContext.Pokemons.Where(poke => poke.Name.Contains(filter)).Skip(offset)
            .Take(limit).ToListAsync(cancellationToken);

        foreach (var pokemon in filteredPokemons)
        {
            var types = await pokemonDbContext.Types.Where(type => pokemon.Id == type.PokemonId).ToListAsync(cancellationToken);
            pokemon.Types = types;
        }
        
        return filteredPokemons.Select(MapPokemonDetailedToPokemonResponseDto).ToList();
    }

    /// <inheritdoc />
    public async Task<Pokemon?> GetByIdOrNameAsync(string idOrName,
        CancellationToken cancellationToken)
    {
        Pokemon? pokemon;
        if (int.TryParse(idOrName, out var id))
        {
            pokemon = await pokemonDbContext.Pokemons.FirstOrDefaultAsync(x => x.Id.Equals(id),
                cancellationToken: cancellationToken);
        }
        else
        {
            pokemon = await pokemonDbContext.Pokemons.FirstOrDefaultAsync(x => x.Name == idOrName,
                cancellationToken: cancellationToken);
        }

        if (pokemon is null)
            return null;

        var breeding = await pokemonDbContext.Breedings.FirstOrDefaultAsync(breeding => breeding.PokemonId == pokemon.Id, cancellationToken);
        pokemon.Breeding = breeding;
        var abilities = await pokemonDbContext.Abilities.Where(ability => ability.PokemonId == pokemon.Id).ToListAsync(cancellationToken);
        pokemon.Abilities = abilities;
        var moves = await pokemonDbContext.Moves.Where(move => move.PokemonId == pokemon.Id).ToListAsync(cancellationToken);
        pokemon.Moves = moves;
        var types = await pokemonDbContext.Types.Where(type => pokemon.Id == type.PokemonId).ToListAsync(cancellationToken);
        pokemon.Types = types;
        var stats = await pokemonDbContext.Stats.Where(stat => pokemon.Id == stat.PokemonId).ToListAsync(cancellationToken);
        pokemon.Stats = stats;

        return pokemon;
    }

    private static PokemonResponseDto MapPokemonDetailedToPokemonResponseDto(Pokemon pokemon)
    {
        return new PokemonResponseDto
        {
            Id = pokemon.Id,
            Name = pokemon.Name,
            Sprites = pokemon.ImageUrl,
            Types = pokemon.Types
        };
    }
}