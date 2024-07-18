using Microsoft.AspNetCore.Mvc;
using PokeApiWeb.Services;
using System.Net;

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
        public async Task<ActionResult> Get(string pokemon)
        {
            await _spriteDataService.PopulateSpriteImages();

            try
            {
                var img = _spriteDataService.GetSpriteImage(pokemon);

                return File(img, "image/jpeg");
            }
            catch (Exception ex)
            {
                return BadRequest("Pokemon not found" + ex.Message);
            }
        }
    }
}