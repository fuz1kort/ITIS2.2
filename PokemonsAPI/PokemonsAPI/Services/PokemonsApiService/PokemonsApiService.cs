using PokemonsAPI.Models;

namespace PokemonsAPI.Services;

/// <summary>
/// Сервис для получения покемонов
/// </summary>
public class PokemonsApiService : IPokemonsApiService
{
    private List<Pokemon?> _data =
    [
        new Pokemon { Id = 1, Name = "First", Url = "" },
        new Pokemon { Id = 2, Name = "Second", Url = "" },
        new Pokemon { Id = 3, Name = "Anton", Url = "" },
        new Pokemon { Id = 4, Name = "Ne Anton", Url = "" }
    ];

    public PokemonsApiService()
    {
    }

    public IEnumerable<object> GetAllPokemons()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<object> GetByFilter(string name)
    {
        throw new NotImplementedException();
    }

    public Pokemon? GetByIdOrName(string nameOrId)
    {
        throw new NotImplementedException();
    }
}