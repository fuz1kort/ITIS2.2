namespace PokemonsAPI.Core.Interfaces;

public interface IPokemonDbContextSeeder
{
    /// <summary>
    /// Инициализация базы данных начальными данными.
    /// </summary>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    Task SeedAsync(CancellationToken cancellationToken = default);
}