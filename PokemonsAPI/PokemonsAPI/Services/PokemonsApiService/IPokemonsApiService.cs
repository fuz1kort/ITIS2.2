using PokemonsAPI.Models;

namespace PokemonsAPI.Services.PokemonsApiService;

/// <summary>
/// Интерфейс сервиса PokemonsApiService
/// </summary>
public interface IPokemonsApiService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    public Task<IEnumerable<Pokemon>> GetByFilterAsync(string filter = "", int offset = 0);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nameOrId"></param>
    /// <returns></returns>
    public Task<Pokemon?> GetByIdOrNameAsync(string nameOrId);
}