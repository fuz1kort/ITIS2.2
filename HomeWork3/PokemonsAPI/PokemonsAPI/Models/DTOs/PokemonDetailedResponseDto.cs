using System.Collections.Generic;

namespace PokemonsAPI.Models.DTOs;

/// <summary>
/// 
/// </summary>
public class PokemonDetailedResponseDto
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
    public int Height { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public int Weight { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<MoveInfoDto> Moves { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    public List<AbilityInfoDto> Abilities { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    public SpriteInfoDto Sprites { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    public List<TypeInfoDto> Types { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    public List<StatInfoDto> Stats { get; set; } = null!;
}