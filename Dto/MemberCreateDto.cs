using System.ComponentModel.DataAnnotations;

namespace AmsterdamSportInc.DTO
{
    public class MemberCreateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
    }
}