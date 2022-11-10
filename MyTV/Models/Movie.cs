using System.ComponentModel.DataAnnotations;
namespace MyTV.Models
{
    public class Movie : Media
    {
        [Required]
        public int Duration { get; set; }
    }
}
