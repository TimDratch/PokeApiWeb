using Newtonsoft.Json;
using PokeApi.Contracts.Enums;

namespace PokeApiWeb.Services
{

    public class JsonSerializerService : IJsonSerializerService
    {

        public void WriteToFile<T>(StoredData dataType, T data)
        {
            using StreamWriter file = File.CreateText(@$"Data\{dataType}.json");
            var serializer = new JsonSerializer();

            serializer.Serialize(file, data);
        }

        public T ReadFromFile<T>(StoredData dataType)
        {
            if (!File.Exists(@$"Data\{dataType}.json"))
                return default;

            using StreamReader r = new(@$"Data\{dataType}.json");
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}

