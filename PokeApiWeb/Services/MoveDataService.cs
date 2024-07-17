using PokeApi.Contracts.Enums;

namespace PokeApiWeb.Services
{
    public class MoveDataService : PopulateDataServiceBase
    {
        public MoveDataService(IJsonSerializerService serializerService): base(serializerService)
        {

        }

        public override StoredData DataType => StoredData.Moves;

        public override string Url => "https://pokeapi.co/api/v2/move";
    }
}
