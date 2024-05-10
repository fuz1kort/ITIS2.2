using PokemonsAPI.Models.DTOs;

namespace PokemonsAPI.Services.PokemonApiService;

/// <summary>
/// 
/// </summary>
public interface IPokemonApiService
{
    /// <summary>
    /// Filters Pokemons by given filter
    /// </summary>
    /// <param name="offset"></param>
    /// <param name="limit"></param>
    /// <param name="filter">Used for filter</param>
    /// <returns>List of <see cref="PokemonResponseDto"/></returns>
    Task<List<PokemonResponseDto>> GetByFilterAsync(string filter = "", int limit = 70, int offset = 0);
    
    /// <summary>
    ///
    /// </summary>
    /// <param name="idOrName">Id or Name used for search</param>
    /// <returns><see cref="PokemonDetailedDto"/></returns>
    Task<PokemonDetailedDto?> GetByIdOrNameAsync(string idOrName);
}