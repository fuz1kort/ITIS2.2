using Type = PokemonsAPI.Core.Entities.Type;

namespace PokemonsAPI.Core.Models;

public class PokemonResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Sprites { get; set; }
    public List<Type> Types { get; set; }
}