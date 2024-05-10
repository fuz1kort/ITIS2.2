using System.Text.Json.Serialization;

namespace PokemonsAPI.Core.Models.PokemonApiModels;

public class SpriteOtherHome
{
    [JsonPropertyName("front_default")]
    public string Front_Default { get; set; }
}