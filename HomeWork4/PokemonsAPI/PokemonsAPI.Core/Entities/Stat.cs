namespace PokemonsAPI.Core.Entities;

public class Stat
{
    public Guid Id { get; set; }

    public int PokemonId { get; set; }
    
    public string StatName { get; set; } = default!;

    public int StatValue { get; set; }
}