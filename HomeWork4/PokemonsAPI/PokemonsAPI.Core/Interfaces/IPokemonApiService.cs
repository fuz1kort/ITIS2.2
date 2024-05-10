using PokemonsAPI.Core.Entities;
using PokemonsAPI.Core.Models;

namespace PokemonsAPI.Core.Interfaces;

/// <summary>
/// 
/// </summary>
public interface IPokemonApiService
{
    /// <summary>
    /// Filters Pokemons by given filter
    /// </summary>
    /// <param name="offset"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="limit"></param>
    /// <param name="filter">Used for filter</param>
    Task<List<PokemonResponseDto>> GetByFilterAsync(string filter = "", CancellationToken cancellationToken = default, int limit = 20, int offset = 0);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="idOrName">Id or Name used for search</param>
    /// <param name="cancellationToken"></param>
    Task<Pokemon?> GetByIdOrNameAsync(string idOrName, CancellationToken cancellationToken = default);
}