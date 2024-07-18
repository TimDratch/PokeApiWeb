using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PokeUi.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string ImageUrl = @"https://localhost:7197/Sprite/snorlax";
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string PokemonName { get; set; }
        }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public  ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Please submit a Pokemon name";
                return Page();
            }

            try
            {

                return RedirectToPage("/Pokemon", new { pokemonName = Input.PokemonName});
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}