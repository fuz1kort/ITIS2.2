namespace PokemonsAPI.Core.Entities;

public class Ability
{
    public Guid Id { get; set; }

    public int PokemonId { get; set; }
    
    public string AbilityName { get; set; } = default!;
}