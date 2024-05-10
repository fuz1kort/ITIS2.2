using System.Text.Json.Serialization;

namespace PokemonsAPI.Core.Models.PokemonApiModels;

public class PokemonInfo
{
    [JsonPropertyName("name")]
    public string PokemonName { get; set; }
    
    [JsonPropertyName("url")]
    public Uri PokemonUrl { get; set; }
}