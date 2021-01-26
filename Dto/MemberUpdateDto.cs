using System.ComponentModel.DataAnnotations;

namespace AmsterdamSportInc.Dto
{
    public class MemberUpdateDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }
    }
}