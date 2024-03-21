using Microsoft.AspNetCore.Mvc;
using PokemonsAPI.Models;
using PokemonsAPI.Services;
using PokemonsAPI.Services.PokemonMapperService;

namespace PokemonsAPI.Controllers
{
    /// <inheritdoc />
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonsController : ControllerBase
    {
        private readonly IPokemonsApiService _pokemonsApiService;
        private readonly IPokemonMapperService _mapper;

        /// <inheritdoc />
        public PokemonsController(IPokemonsApiService pokemonsApiService, IPokemonMapperService mapper)
        {
            _pokemonsApiService = pokemonsApiService;
            _mapper = mapper;
        }

        private static readonly List<Pokemon?> Data =
        [
            new Pokemon { Id = 1, Name = "First", Url = "" },
            new Pokemon { Id = 2, Name = "Second", Url = "" },
            new Pokemon { Id = 3, Name = "Anton", Url = "" },
            new Pokemon { Id = 4, Name = "Ne Anton", Url = "" }
        ];

        /// <summary>
        /// Метод для получения всех покемонов
        /// </summary>
        /// <returns>Возвращает список всех покемонов в системе</returns>
        // GET: api/Pokemon
        [HttpGet]
        public IEnumerable<object> Get()
        {
            return Data.Select(p => new { p.Id, p.Name, p.Url });
        }

        /// <summary>
        /// Метод для получения покемонов по указанной строке пользователя
        /// </summary>
        /// <returns>Возвращает список всех найденых покемонов в системе</returns>
        [HttpGet("GetByFilter")]
        public IEnumerable<object> GetByFilter([FromQuery] string name)
        {
            return Data.Where(p => p != null && p.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .Select(p => new { p.Id, p.Name, p.Url });
        }

        /// <summary>
        /// Метод для получения всей информации по одному покемону
        /// </summary>
        /// <returns>Возвращает полную информацию о покемоне по заданному Id или Name</returns>
        // GET: api/Pokemon/5
        [HttpGet("{nameOrId}")]
        public Pokemon? GetByIdOrName([FromRoute] string nameOrId)
        {
            return int.TryParse(nameOrId, out var id)
                ? Data.FirstOrDefault(p => p != null && p.Id == id)
                : Data.FirstOrDefault(p => p != null && p.Name.Equals(nameOrId, StringComparison.OrdinalIgnoreCase));
        }
    }
}