using System.Text.Json.Serialization;

namespace PokemonsAPI.Core.Models.PokemonApiModels;

public class Sprites
{
    [JsonPropertyName("other")]
    public SpriteOther Other { get; set; }
}