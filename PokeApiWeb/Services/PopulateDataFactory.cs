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

            if (dataService == null)
                throw new InvalidEnumArgumentException($"No concrete class found for {storedDataType}");

            return dataService;
        }
    }
}
