using System.Collections.Generic;
using AmsterdamSportInc.Dto;

namespace AmsterdamSportInc.Models
{
    public class MemberReadDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public ICollection<SportReadDto> Sports { get; set; }
    }
}