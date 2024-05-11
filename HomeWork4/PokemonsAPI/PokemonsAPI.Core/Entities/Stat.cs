namespace PokemonsAPI.Core.Entities;

public class Stat
{
    public Guid Id { get; set; }

    public Guid PokemonId { get; set; }
    
    public string StatName { get; set; } = default!;

    public int StatValue { get; set; }
}