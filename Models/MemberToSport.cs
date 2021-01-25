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
        public int Id { get; set;}
        public int MemberId { get; set; }
        public string SportName { get; set; }
    }
}