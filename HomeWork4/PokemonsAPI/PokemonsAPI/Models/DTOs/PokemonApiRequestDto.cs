using System.Collections.Generic;

namespace PokemonsAPI.Models.DTOs;

/// <summary>
/// 
/// </summary>
public class PokemonApiRequestDto
{
    /// <summary>
    /// 
    /// </summary>
    public List<Pokemon> Results { get; init; } = new();
}