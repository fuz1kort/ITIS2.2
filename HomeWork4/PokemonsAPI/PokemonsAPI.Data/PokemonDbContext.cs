using Microsoft.EntityFrameworkCore;
using PokemonsAPI.Core.Entities;
using PokemonsAPI.Core.Interfaces;
using Type = PokemonsAPI.Core.Entities.Type;

namespace PokemonsAPI.Data;

public class PokemonDbContext : DbContext, IPokemonDbContext
{
    public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<Breeding> Breedings { get; set; }
    public DbSet<Ability> Abilities { get; set; }
    public DbSet<Move> Moves { get; set; }
    public DbSet<Stat> Stats { get; set; }
    public DbSet<Type> Types { get; set; }

    public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
    {
    }
}