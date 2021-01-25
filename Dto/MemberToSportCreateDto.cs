using System.ComponentModel.DataAnnotations;

namespace AmsterdamSportInc.Dto
{
    public class MemberToSportCreateDto
    {
        [Required]
        public int MemberId { get; set; }
        [Required]
        public string SportName { get; set; }
    }
}
