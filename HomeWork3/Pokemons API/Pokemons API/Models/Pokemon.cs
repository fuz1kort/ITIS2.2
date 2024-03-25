namespace Pokemons_API.Models;

public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public Params Params { get; set; }
}