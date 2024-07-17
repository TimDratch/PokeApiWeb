using Flurl.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeApi.Contracts.Models;
using System.Text.Json;

namespace PokeUi.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        readonly string Url = @"https://localhost:7197/pokemon/snorlax";

        public string ImageUrl;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async void OnGet()
        {
            var pokedata = await Url.GetJsonAsync<PokemonData>();

            ImageUrl = pokedata.Sprites.Front_Default;
        }
    }

}