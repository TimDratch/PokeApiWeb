using PokeApi.Contracts.Enums;
using PokeApi.Contracts.Models;

namespace PokeApiWeb.Services
{
    public interface IPopulateDataService
    {
        StoredData DataType { get; }
        Task<List<Value>> Populate();
    }
}
