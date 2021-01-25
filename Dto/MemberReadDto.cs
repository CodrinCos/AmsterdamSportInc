using System.Collections.Generic;

namespace AmsterdamSportInc.Models
{
    public class MemberReadDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public ICollection<Sport> Sports { get; set; }
    }
}