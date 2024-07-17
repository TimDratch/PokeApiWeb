using PokeApi.Contracts.Enums;

namespace PokeApiWeb.Services
{
    public interface IPopulateDataFactory
    {
        public IPopulateDataService Get(StoredData storedData);
    }
}
