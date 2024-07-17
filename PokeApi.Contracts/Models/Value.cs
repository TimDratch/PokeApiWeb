using System.Runtime.Serialization;

namespace PokeApi.Contracts.Models
{
    [DataContract]
    public class Value
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}
