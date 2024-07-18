using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PokeUi.Pages
{
    public class PokemonModel : PageModel
    {
        private readonly ILogger<PokemonModel> _logger;
        public string ImageUrl = "https://localhost:7197/Sprite/";

        public PokemonModel(ILogger<PokemonModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(string pokemonName)
        {
            ViewData["pokemonName"] = pokemonName;
            ImageUrl += pokemonName;
        }
    }
}