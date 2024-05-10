using System.Text.Json.Serialization;

namespace PokemonsAPI.Core.Models.PokemonApiModels;

public class PokemonsInfo
{
    [JsonPropertyName("count")]
    public int PokemonsCount { get; set; }
    
    [JsonPropertyName("results")]
    public List<PokemonInfo> Pokemons { get; set; }
}