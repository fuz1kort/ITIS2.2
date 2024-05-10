using System.Text.Json.Serialization;

namespace PokemonsAPI.Core.Models.PokemonApiModels;

public class Ability
{
    [JsonPropertyName("ability")]
    public AbilityValue AbilityValue { get; set; }
}