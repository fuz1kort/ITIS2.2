using PokemonsAPI.Models;

namespace PokemonsAPI.Services.PokemonMapperService;

/// <summary>
/// 
/// </summary>
public interface IPokemonMapperService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="json"></param>
    /// <typeparam name="TPokemon"></typeparam>
    /// <returns></returns>
    public TPokemon Map<TPokemon>(string json);
}