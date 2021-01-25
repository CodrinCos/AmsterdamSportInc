using System.ComponentModel.DataAnnotations;

namespace AmsterdamSportInc.Models
{
    //This Model does not make much sense, since the relation one to many can be made with EF in the Member class
    //But I will explain in the presentation why I decided to go this way.
    public class MemberToSport
    {
        public MemberToSport(int memberId, string sportName)
        {
            this.SportName = sportName;
            this.MemberId = memberId;
        }
        [Key]
        public int Id { get; set;}
        [Required]
        public int MemberId { get; set; }
        [Required]
        public string SportName { get; set; }
    }
}