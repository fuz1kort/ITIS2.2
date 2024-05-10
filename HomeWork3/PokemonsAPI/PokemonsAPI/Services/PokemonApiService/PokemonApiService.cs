using System.Net;
using Newtonsoft.Json;
using PokemonsAPI.Models.DTOs;

namespace PokemonsAPI.Services.PokemonApiService;

/// <summary>
/// 
/// </summary>
public class PokemonApiService : IPokemonApiService
{
    private readonly HttpClient _httpClient = new();
    private const string? PokemonApiUrl = "https://pokeapi.co/api/v2/pokemon";

    /// <inheritdoc />
    public async Task<List<PokemonResponseDto>> GetByFilterAsync(string filter = "", int limit = 70, int offset = 0)
    {
        var response = await _httpClient.GetStringAsync(PokemonApiUrl + $"?limit={limit}" + $"&offset={offset}");
        var pokemonList = JsonConvert.DeserializeObject<PokemonApiRequestDto>(response);

        if (pokemonList is null)
            throw new NullReferenceException("Pokemons are not existing anymore!");
        
        var pokemonListFiltered = pokemonList.Results
            .Where(i => i.Name.Contains(filter, StringComparison.CurrentCultureIgnoreCase))
            .ToList();
        var pokemonDetailedList = new List<PokemonDetailedDto>();
        foreach (var pokemon in pokemonListFiltered)
        {
            var pokemonDetailed = await _httpClient.GetFromJsonAsync<PokemonDetailedDto>(pokemon.Url);

            if (pokemonDetailed is null)
                throw new NullReferenceException("Pokemon does not exist!");
            pokemonDetailedList.Add(pokemonDetailed);
        }

        var pokemonResponseDtoList = pokemonDetailedList
            .Select(MapPokemonDetailedToPokemonResponseDto)
            .ToList();

        return pokemonResponseDtoList;
    }

    /// <inheritdoc />
    public async Task<PokemonDetailedDto?> GetByIdOrNameAsync(string idOrName)
    {
        var response = await _httpClient.GetAsync(PokemonApiUrl + $"/{idOrName.ToLower()}");

        if (response.StatusCode == HttpStatusCode.NotFound)
            return null;

        var responseData = await response.Content.ReadAsStringAsync();
        var pokemonDetailed = JsonConvert.DeserializeObject<PokemonDetailedDto>(responseData);

        return pokemonDetailed;

    }

    private static PokemonResponseDto MapPokemonDetailedToPokemonResponseDto(PokemonDetailedDto pokemonDetailed)
    {
        return new PokemonResponseDto
        {
            Id = pokemonDetailed.Id,
            Name = pokemonDetailed.Name,
            Sprites = pokemonDetailed.Sprites,
            Types = pokemonDetailed.Types
        };
    }
}