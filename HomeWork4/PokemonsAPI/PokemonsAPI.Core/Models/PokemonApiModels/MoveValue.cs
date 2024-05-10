using System.Text.Json.Serialization;

namespace PokemonsAPI.Core.Models.PokemonApiModels;

public class MoveValue
{
    [JsonPropertyName("name")]
    public string MoveName { get; set; }
}