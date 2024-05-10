using Microsoft.AspNetCore.Mvc;
using PokemonsAPI.Services.PokemonApiService;

namespace PokemonsAPI.Controllers;

/// <summary>
/// Контроллер
/// </summary>
[Route("[controller]/[action]")]
[ApiController]
public sealed class PokemonController : ControllerBase
{
    private readonly IPokemonApiService _pokeApiService;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pokeApiService"></param>
    public PokemonController(IPokemonApiService pokeApiService)
    {
        _pokeApiService = pokeApiService;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll(int limit, int offset)
    {
        var pokemonDataDtoList = await _pokeApiService.GetByFilterAsync("", limit, offset);
        return Ok(pokemonDataDtoList);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{filter}")]
    public async Task<IActionResult> GetByFilter(int limit, int offset, string filter)
    {
        var pokemonsListDataDto = await _pokeApiService.GetByFilterAsync(filter);
        return Ok(pokemonsListDataDto);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="idOrName"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{idOrName}")]
    public async Task<IActionResult> GetByIdOrName(string idOrName)
    {
        var pokemonDataDto = await _pokeApiService.GetByIdOrNameAsync(idOrName);

        if (pokemonDataDto is null)
            return NotFound();
 
        return Ok(pokemonDataDto);
    }
}