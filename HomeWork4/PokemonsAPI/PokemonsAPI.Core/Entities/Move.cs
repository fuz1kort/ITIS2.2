namespace PokemonsAPI.Core.Entities;

public class Move
{
    public Guid Id { get; set; }

    public Guid PokemonId { get; set; }

    public string MoveName { get; set; } = default!;
}