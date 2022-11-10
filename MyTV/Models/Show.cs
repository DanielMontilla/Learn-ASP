using System.ComponentModel.DataAnnotations;
namespace MyTV.Models
{
    public class Show : Media
    {
        [Required]
        public bool Ongoing { get; set; }
    }
}
