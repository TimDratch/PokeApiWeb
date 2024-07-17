using Flurl.Http;
using PokeApi.Contracts.Enums;
using PokeApi.Contracts.Models;

namespace PokeApiWeb.Services
{

    public class PopulateDataServiceBase : IPopulateDataService
    {
        public IJsonSerializerService _serializerService;

        public PopulateDataServiceBase(IJsonSerializerService serializerService)
        {
            _serializerService = serializerService;
        }

        public virtual StoredData DataType => StoredData.Default;
        public virtual string Url => string.Empty;

        public ListData Data => new() { Values = _serializerService.ReadFromFile<List<Value>>(DataType)};
        public virtual async Task<List<Value>> Populate()
        {

            if (!Data.Values.Any())
            {
                Data.Url = Url;

                while (!string.IsNullOrEmpty(Data.Url))
                {
                    var response = await Data.Url
                                    .GetJsonAsync<ListData>();

                    Data.Values.AddRange(response.Values);
                    Data.Url = response.Url;
                }
                _serializerService.WriteToFile<List<Value>>(DataType, Data.Values);
            }
            return Data.Values;
        }
    }
}

