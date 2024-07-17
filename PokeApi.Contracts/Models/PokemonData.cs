using System.Runtime.Serialization;

namespace PokeApi.Contracts.Models
{
    [DataContract]
    public class PokemonData
    {
        [DataMember(Name = "abilities")]
        public AbilityValue[] Abilities { get; set; }

        [DataMember(Name = "base_experience")]
        public int Base_Experience { get; set; }

        [DataMember(Name = "forms")]
        public Value[] Forms { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "moves")]
        public MoveValue[] Moves { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "species")]
        public Value Species { get; set; }

        [DataMember(Name = "stats")]
        public StatValue[] Stats { get; set; }

        [DataMember(Name = "types")]
        public TypeValue[] Types { get; set; }

        [DataMember(Name = "sprites")]
        public Sprites Sprites { get; set; }
    }
}
