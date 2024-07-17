using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using PokeApi.Contracts.Enums;
using PokeApi.Contracts.Models;
using PokeApiWeb.Services;

namespace PokeApiWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        readonly IPopulateDataFactory _dataFactory;
        public IPopulateDataService _dataService;
        private readonly ILogger<PokemonController> _logger;

        public PokemonController(ILogger<PokemonController> logger, IPopulateDataFactory dataFactory)
        {
            _logger = logger;
            _dataFactory = dataFactory;
            _dataService = _dataFactory.Get(StoredData.Pokemon);
        }

        [HttpGet("{pokemon}")]
        public async Task<ActionResult<PokemonData>> Get(string pokemon)
        {
            var pokedex = await _dataService.Populate();

            var pokedexEntry = pokedex.SingleOrDefault(x => x.Name == pokemon);

            if (pokedexEntry is null)
                return BadRequest("Pokemon not found");

            var data =  await pokedexEntry.Url.GetJsonAsync<PokemonData>();

            return Ok(data);
        }
    }
}