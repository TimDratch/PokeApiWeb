using System.Runtime.Serialization;

namespace PokeApi.Contracts.Models
{
    [DataContract]
    public class ListData
    {
        [DataMember(Name = "next")]
        public string Url { get; set; } = string.Empty;

        [DataMember(Name = "results")]
        public List<Value> Values { get; set; } = new List<Value>();
    }
}
