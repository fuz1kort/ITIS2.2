namespace PokemonsAPI.Models;

/// <summary>
/// 
/// </summary>
public class Pokemon
{
    /// <summary>
    /// 
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? Url { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Breeding? Breeding { get; set; }
}