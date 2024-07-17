using System.Runtime.Serialization;

namespace PokeApi.Contracts.Models
{
    [DataContract]
    public class Sprites
    {
        [DataMember(Name = "front_default")]
            public string Front_Default { get; set; }
    }
}
