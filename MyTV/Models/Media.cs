using System.ComponentModel.DataAnnotations;
namespace MyTV.Models
{
    public class Media
    {
        public int Id { get; set; }

        [Required, MaxLength(128)]
        public string Title { get; set; }

        [Required, MaxLength(255)]
        public string Description { get; set; }

        [Required, Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        public bool? Watched { get; set; }

    }
}
