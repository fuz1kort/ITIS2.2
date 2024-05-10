using System.Text.Json.Serialization;

namespace PokemonsAPI.Core.Models.PokemonApiModels;

public class Type
{
    [JsonPropertyName("type")]
    public TypeValue TypeValue { get; set; }
}