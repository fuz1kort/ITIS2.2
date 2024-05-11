namespace PokemonsAPI.Core.Entities;

public class Breeding
{
    public Guid Id { get; set; }
    
    public Guid PokemonId { get; set; }
    
    public int Weight { get; set; }
    
    public int Height { get; set; }
}