namespace PokemonsAPI.Core.Entities;

public class Type
{
    public Guid Id { get; set; }
    
    public Guid PokemonId { get; set; }
    
    public string TypeName { get; set; } = default!;
}