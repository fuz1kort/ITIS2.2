using System.Text.Json.Serialization;

namespace PokemonsAPI.Core.Models.PokemonApiModels;

public class AbilityValue
{
    [JsonPropertyName("name")]
    public string AbilityName { get; set; }
}