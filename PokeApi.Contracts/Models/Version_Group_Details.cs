using System.Runtime.Serialization;

namespace PokeApi.Contracts.Models
{

    [DataContract]
    public class Version_Group_Details
    {
        [DataMember(Name = "level_learned_at")]
        public int Level_Learned_At { get; set; }

        [DataMember(Name = "move_learn_method")]
        public Value Move_Learn_Method { get; set; }

        [DataMember(Name = "version_group")]
        public Value Version_Group { get; set; }
    }
}
