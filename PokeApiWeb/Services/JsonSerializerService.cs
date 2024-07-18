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

        public async void WriteImageToFile(StoredData dataType, string fileName, string url)
        {
            var path = $@"Data\Images\{dataType}\{fileName}";
            if (File.Exists(path))
                return;

            using var client = new HttpClient();
            try
            {
                var response = await client.GetAsync(url);

                using var stream = await response.Content.ReadAsStreamAsync();

                using var fs = new FileStream(path, FileMode.Create, FileAccess.Write);
                await response.Content.CopyToAsync(fs);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

