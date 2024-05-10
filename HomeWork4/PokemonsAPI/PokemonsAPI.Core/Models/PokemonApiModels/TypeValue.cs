using System.Text.Json.Serialization;

namespace PokemonsAPI.Core.Models.PokemonApiModels;

public class TypeValue
{
    [JsonPropertyName("name")]
    public string TypeName { get; set; }
}