using Newtonsoft.Json;
using PokemonsAPI.Models;
using PokemonsAPI.Models.DTOs;

namespace PokemonsAPI.Services.PokemonsApiService;

/// <summary>
/// Сервис для получения покемонов
/// </summary>
public class PokemonsApiService : IPokemonsApiService
{
    private const string Url = "https://pokeapi.co/api/v2/pokemon";
    private readonly HttpClient _client = new();
    private const int Limit = 40;

    /// <inheritdoc />
    public async Task<IEnumerable<Pokemon>> GetByFilterAsync(string filter = "", int offset = 0)
    {
        var response = await _client.GetStringAsync(Url + $"?limit={Limit}" + $"&offset={offset}");
        
        var pokemonList = JsonConvert.DeserializeObject<PokemonListDto>(response);

        if (pokemonList is null)
            throw new ArgumentException("No pokemons");
        return pokemonList.Results;
        // return _data.Where(p => p != null && p.Name.Contains(filter, StringComparison.OrdinalIgnoreCase))
        //     .Select(p => new { p.Id, p.Name, p.Url });
    }

    /// <inheritdoc />
    public async Task<Pokemon?> GetByIdOrNameAsync(string nameOrId)
    {
        // return int.TryParse(nameOrId, out var id)
        //     ? _data.FirstOrDefault(p => p != null && p.Id == id)
        //     : _data.FirstOrDefault(p => p != null && p.Name.Equals(nameOrId, StringComparison.OrdinalIgnoreCase));
        return null;
    }
}