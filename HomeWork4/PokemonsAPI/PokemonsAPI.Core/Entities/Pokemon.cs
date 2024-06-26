namespace PokemonsAPI.Core.Entities;

public class Pokemon
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string? ImageUrl { get; set; }

    public Breeding? Breeding { get; set; }

    public List<Move>? Moves { get; set; }

    public List<Type>? Types { get; set; }

    public List<Ability>? Abilities { get; set; }
    
    public List<Stat>? Stats { get; set; }
}