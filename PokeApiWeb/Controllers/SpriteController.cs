using Microsoft.AspNetCore.Mvc;
using PokeApi.Contracts.Enums;
using PokeApiWeb.Services;

namespace PokeApiWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpriteController : ControllerBase
    {
        readonly IPopulateSpriteDataService _spriteDataService;
        public IPopulateDataService _dataService;
        private readonly ILogger<SpriteController> _logger;

        public SpriteController(ILogger<SpriteController> logger, IPopulateSpriteDataService spriteDataService)
        {
            _logger = logger;
            _spriteDataService = spriteDataService;
        }

        [HttpGet("{pokemon}")]
        public async Task<ActionResult<string>> Get(string pokemon)
        {
            var spriteList = await _spriteDataService.Populate();

            var sprite = spriteList.SingleOrDefault(x => x.Name == pokemon);

            if (sprite is null)
                return BadRequest("Pokemon not found");


            return Ok(sprite.Url);
        }
    }
}