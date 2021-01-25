using System.ComponentModel.DataAnnotations;

namespace AmsterdamSportInc.Models
{
    public class Sport
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}