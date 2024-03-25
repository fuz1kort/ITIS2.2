using Microsoft.AspNetCore.Mvc;
using Pokemons_API.Models;

namespace Pokemons_API.Controllers;

/// <summary>
/// Салам
/// </summary>
[Route("api/[controller]")]
[ApiController]
public sealed class PokemonController : ControllerBase
{
    // // GET: api/<PokemonController>
    // [HttpGet]
    // public IEnumerable<string> Get()
    // {
    //     return new[] { "value1", "value2" };
    // }
    //
    // // GET api/<PokemonController>/5
    // [HttpGet("{id:int}")]
    // public string GetPokemonById(int id)
    // {
    //     return "value";
    // }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pagination"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public Pokemon GetPokemonByIdOrName([FromRoute] int id, [FromQuery] PaginationParams pagination)
    {
        return new Pokemon();
    }

    // [HttpGet("{name}")]
    // public string GetPokemonByName(string name)
    // {
    //     return "value2";
    // }
}