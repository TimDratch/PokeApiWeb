using System.Runtime.Serialization;

namespace PokeApi.Contracts.Models
{
    [DataContract]
    public class TypeValue
    {
        [DataMember(Name = "slot")]
        public int Slot { get; set; }

        [DataMember(Name = "type")]
        public Value Type { get; set; }
    }
}
