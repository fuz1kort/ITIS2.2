using System.Text.Json.Serialization;

namespace PokemonsAPI.Core.Models.PokemonApiModels;

public class StatValue
{
    [JsonPropertyName("name")]
    public string StatName { get; set; }
}