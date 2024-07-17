using System.Runtime.Serialization;

namespace PokeApi.Contracts.Models
{
    [DataContract]
    public class AbilityValue
    {
        [DataMember(Name = "ability")]
        public Value Ability { get; set; }

        [DataMember(Name = "is_hidden")]
        public bool Is_Hidden { get; set; }

        [DataMember(Name = "slot")]
        public int Slot { get; set; }
    }
}
