using System.ComponentModel.DataAnnotations;

namespace AmsterdamSportInc.Dto
{
    public class SportReadDto
    {
        [Required]
        public string Name { get; set; }
    }
}