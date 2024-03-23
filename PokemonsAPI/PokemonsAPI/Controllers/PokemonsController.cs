using Microsoft.AspNetCore.Mvc;
using PokemonsAPI.Models;
using PokemonsAPI.Services.PokemonsApiService;

namespace PokemonsAPI.Controllers
{
    /// <inheritdoc />
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonsController : ControllerBase
    {
        private readonly IPokemonsApiService _pokemonsApiService;

        /// <inheritdoc />
        public PokemonsController(IPokemonsApiService pokemonsApiService) => _pokemonsApiService = pokemonsApiService;

        /// <summary>
        /// Метод для получения всех покемонов
        /// </summary>
        /// <returns>Возвращает список всех покемонов в системе</returns>
        // GET: api/Pokemon
        [HttpGet]
        public IEnumerable<Pokemon> Get(int limit, int offset)
        {
            return _pokemonsApiService.GetByFilterAsync("", offset).Result;
        }

        /// <summary>
        /// Метод для получения покемонов по указанной строке пользователя
        /// </summary>
        /// <returns>Возвращает список всех найденых покемонов в системе</returns>
        [HttpGet("GetByFilter")]
        public async Task<IEnumerable<Pokemon>> GetByFilter(string filter, int offset)
        {
            return await _pokemonsApiService.GetByFilterAsync(filter, offset);
        }

        /// <summary>
        /// Метод для получения всей информации по одному покемону
        /// </summary>
        /// <returns>Возвращает полную информацию о покемоне по заданному Id или Name</returns>
        // GET: api/Pokemon/5
        [HttpGet("{nameOrId}")]
        public async Task<Pokemon?> GetByIdOrName([FromRoute] string nameOrId)
        {
            return await _pokemonsApiService.GetByIdOrNameAsync(nameOrId);
        }
    }
}