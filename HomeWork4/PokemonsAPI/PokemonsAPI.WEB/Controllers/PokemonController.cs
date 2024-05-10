using Microsoft.AspNetCore.Mvc;
using PokemonsAPI.Core.Interfaces;

namespace PokemonsAPI.WEB.Controllers;

/// <summary>
/// Контроллер
/// </summary>
[Route("[controller]/[action]")]
[ApiController]
public sealed class PokemonController : ControllerBase
{
    private readonly IPokemonApiService _pokemonApiService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pokemonApiService"></param>
    public PokemonController(IPokemonApiService pokemonApiService) => _pokemonApiService = pokemonApiService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll(int limit, int offset, CancellationToken cancellationToken)
    {
        var pokemonDataDtoList = await _pokemonApiService.GetByFilterAsync("", cancellationToken, limit, offset);
        return Ok(pokemonDataDtoList);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="limit"></param>
    /// <param name="offset"></param>
    /// <param name="filter"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [Route("{filter}")]
    public async Task<IActionResult> GetByFilter(int limit, int offset, string filter,
        CancellationToken cancellationToken)
    {
        var pokemonsListDataDto = await _pokemonApiService.GetByFilterAsync(filter, cancellationToken);
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
        var pokemonDataDto = await _pokemonApiService.GetByIdOrNameAsync(idOrName);

        if (pokemonDataDto is null)
            return NotFound();

        return Ok(pokemonDataDto);
    }
}