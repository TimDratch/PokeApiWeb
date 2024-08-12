using PokeApi.Contracts.Enums;
using System.ComponentModel;

namespace PokeApiWeb.Services
{
    public class PopulateDataFactory : IPopulateDataFactory
    {
        public PopulateDataFactory(IEnumerable<IPopulateDataService> dataServices)
        {
            _dataServices = dataServices;
        }

        readonly IEnumerable<IPopulateDataService> _dataServices;

        public IPopulateDataService Get(StoredData storedDataType)
        {
            var dataService = _dataServices.SingleOrDefault(x => x.DataType == storedDataType);

            return dataService ?? throw new InvalidEnumArgumentException($"No concrete class found for {storedDataType}");
        }
    }
}
