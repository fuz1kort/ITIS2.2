using PokemonsAPI.Models;

namespace PokemonsAPI.Services;

/// <summary>
/// Интерфейс сервиса PokemonsApiService
/// </summary>
public interface IPokemonsApiService
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IEnumerable<object> GetAllPokemons();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public IEnumerable<object> GetByFilter(string name);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="nameOrId"></param>
    /// <returns></returns>
    public Pokemon? GetByIdOrName(string nameOrId);
}