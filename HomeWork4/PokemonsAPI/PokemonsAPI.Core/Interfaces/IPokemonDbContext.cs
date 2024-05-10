using Microsoft.EntityFrameworkCore;
using PokemonsAPI.Core.Entities;
using Type = PokemonsAPI.Core.Entities.Type;

namespace PokemonsAPI.Core.Interfaces;

/// <summary>
/// Контекст БД
/// </summary>
public interface IPokemonDbContext
{
    /// <summary>
    /// Способности
    /// </summary>
    DbSet<Ability> Abilities { get; set; }
    
    /// <summary>
    /// Breedings
    /// </summary>
    DbSet<Breeding> Breedings { get; set; }
    
    /// <summary>
    /// Движения
    /// </summary>
    DbSet<Move> Moves { get; set; }
    
    /// <summary>
    /// Покемоны
    /// </summary>
    DbSet<Pokemon> Pokemons { get; set; }
    
    /// <summary>
    /// Статистика
    /// </summary>
    DbSet<Stat> Stats { get; set; }
    
    /// <summary>
    /// Типы
    /// </summary>
    DbSet<Type> Types { get; set; }

    /// <summary>
    /// Сохранение
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}