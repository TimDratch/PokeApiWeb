using PokeApi.Contracts.Models;

namespace PokeApiWeb.Services
{
    public interface IPopulateSpriteDataService
    {
        Task<List<Value>> Populate();
        Task PopulateSpriteImages();
        FileStream GetSpriteImage(string pokemon);
    }
}
