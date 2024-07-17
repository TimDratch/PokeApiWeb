using System.Runtime.Serialization;

namespace PokeApi.Contracts.Models
{
    [DataContract]
    public class StatValue
    {
        [DataMember(Name = "base_stat")]
        public int Base_Stat { get; set; }

        [DataMember(Name = "effort")]
        public int Effort { get; set; }

        [DataMember(Name = "stat")]
        public Value Stat { get; set; }
    }
}
