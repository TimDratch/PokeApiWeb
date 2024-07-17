using System.Runtime.Serialization;

namespace PokeApi.Contracts.Models
{

    [DataContract]
    public class MoveValue
    {
        [DataMember(Name = "move")]
        public Value Move { get; set; }

        [DataMember(Name = "version_group_details")]
        public Version_Group_Details[] Version_Group_Details { get; set; }
    }
}
