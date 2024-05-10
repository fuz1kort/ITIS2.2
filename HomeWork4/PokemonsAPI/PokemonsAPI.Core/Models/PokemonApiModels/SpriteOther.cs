using System.Text.Json.Serialization;

namespace PokemonsAPI.Core.Models.PokemonApiModels;

public class SpriteOther
{
    [JsonPropertyName("home")]
    public SpriteOtherHome Home { get; set; }
}