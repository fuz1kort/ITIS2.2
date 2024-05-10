using Newtonsoft.Json;

namespace PokemonsAPI.Models.DTOs;

/// <summary>
/// 
/// </summary>
public class StatInfoDto
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty(PropertyName = "Base_Stat")]
    public int Base_Stat { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public Stat Stat { get; set; } = null!;
}