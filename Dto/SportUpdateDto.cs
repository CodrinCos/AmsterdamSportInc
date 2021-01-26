using System.ComponentModel.DataAnnotations;

namespace AmsterdamSportInc.Dto
{
    public class SportUpdateDto
    {
        [Required]
        public string Name { get; set; }
    }
}