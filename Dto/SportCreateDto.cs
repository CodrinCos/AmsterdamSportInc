using System.ComponentModel.DataAnnotations;

namespace AmsterdamSportInc.Dto
{
    public class SportCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}