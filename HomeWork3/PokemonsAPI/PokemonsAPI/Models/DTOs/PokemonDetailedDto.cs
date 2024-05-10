namespace PokemonsAPI.Models.DTOs;


/// <summary>
/// 
/// </summary>
public class PokemonDetailedDto
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
    /// </summary>g
    public Breeding? Breeding { get; set; }
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
    public SpriteInfoDto  Sprites  { get; set; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public List<TypeInfoDto> Types { get; set; } = null!;
    /// <summary>
    /// 
    /// </summary>
    public List<StatInfoDto> Stats { get; set; } = null!;
}