using System.Text.Json.Serialization;

namespace PokemonsAPI.Core.Models.PokemonApiModels;

public class Move
{
    [JsonPropertyName("move")]
    public MoveValue MoveValue { get; set; }
}