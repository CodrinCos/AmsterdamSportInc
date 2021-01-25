using System.ComponentModel.DataAnnotations;

namespace AmsterdamSportInc.Dto
{
    public class MemberToSportReadDto
    {
        [Required]
        public int MemberId { get; set; }
        [Required]
        public string SportName { get; set; }
    }
}
