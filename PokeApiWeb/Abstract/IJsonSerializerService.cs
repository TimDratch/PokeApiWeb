using PokeApi.Contracts.Enums;

namespace PokeApiWeb.Services
{
    public interface IJsonSerializerService
    {
        public void WriteToFile<T>(StoredData dataType, T data);
        public T ReadFromFile<T>(StoredData dataType);

        public void WriteImageToFile(StoredData dataType, string fileName, string url);

    }
}
