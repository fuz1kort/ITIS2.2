using System.Collections.Generic;
using PokemonsAPI.Models.DTOs.SpriteIndoDto;

namespace PokemonsAPI.Models.DTOs;

/// <summary>
/// пхпх
/// </summary>
public class PokemonResponseDto
{
    /// <summary>
    /// 
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string Name { get; set; } = "";
    
    /// <summary>
    /// 
    /// </summary>
    public SpriteInfoDto Sprites { get; set; } = null!;
    
    /// <summary>
    /// 
    /// </summary>
    public List<TypeInfoDto> Types { get; set; } = null!;
}