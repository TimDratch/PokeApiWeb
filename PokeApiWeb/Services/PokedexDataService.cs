using PokeApi.Contracts.Enums;

namespace PokeApiWeb.Services
{
    public class PokedexDataService : PopulateDataServiceBase
    {
        public PokedexDataService(IJsonSerializerService serializerService) : base(serializerService)
        {

        }

        public override StoredData DataType => StoredData.Pokemon;
        public override string Url => "https://pokeapi.co/api/v2/pokemon";
    }
}
