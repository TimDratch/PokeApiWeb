using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PokeUi.Pages
{
    public class PokemonModel : PageModel
    {
        private readonly ILogger<PokemonModel> _logger;
        public string ImageUrl = "https://localhost:7197/Sprite/";
        public string PokedexUrl = "https://localhost:7197/Pokemon/";
        public List<string> PokemonNames = new();
        public Dictionary<string, string> PokedexDic = new();
        public PokemonModel(ILogger<PokemonModel> logger)
        {
            _logger = logger;
        }

        public async void OnGet(string pokemonName)
        {
            ViewData["pokemonName"] = pokemonName;
            ImageUrl += pokemonName;
            PokemonNames = await PokedexUrl.GetJsonAsync<List<string>>();
            foreach(var name in PokemonNames)
            {
                PokedexDic.Add(name, "https://localhost:7197/Sprite/" + name);
            }
        }
    }
}