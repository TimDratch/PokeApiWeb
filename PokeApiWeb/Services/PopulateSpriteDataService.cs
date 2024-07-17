using Flurl.Http;
using PokeApi.Contracts.Enums;
using PokeApi.Contracts.Models;

namespace PokeApiWeb.Services
{
    public class PopulateSpriteDataService : IPopulateSpriteDataService
    {
        public IPopulateDataFactory _populateDataFactory;
        public IJsonSerializerService _serializerService;

        public PopulateSpriteDataService(IPopulateDataFactory populateDataFactory, IJsonSerializerService serializerService)
        {
            _populateDataFactory = populateDataFactory;
            _serializerService = serializerService;
        }

        public StoredData DataType => StoredData.Sprites;
        public List<Value> Data  => _serializerService.ReadFromFile<List<Value>>(DataType) ?? new List<Value>();

        //TODO: 1: compile a list of all pokemon with sprite url
        //      2: save/read capability from list to json file (possibly implement PopulateDataServiceBase to avoid duplicating read/save code)
        //      3. Iterate through new json document or list in memory and download sprite png files to Sprite folder
        //      4. call saved png from UI layer
        //      5. add method to search for a single sprite and if it does not exist/missing redownload it

        public async Task<List<Value>> Populate()
        {
            if (!Data.Any())
            {
                var pokemonDataService = _populateDataFactory.Get(StoredData.Pokemon);

                var pokedex = await pokemonDataService.Populate();
                try
                {
                    foreach (var pokemon in pokedex)
                    {
                        var data = await pokemon.Url.GetJsonAsync<PokemonData>();

                        Data.Add(new Value
                        {
                            Name = pokemon.Name,
                            Url = data.Sprites.Front_Default
                        });
                    }
                    _serializerService.WriteToFile<List<Value>>(DataType, Data);
                }
                catch (Exception ex)
                {

                    throw;
                }

            }
            return Data;
        }
    }
}
