using System.ComponentModel.DataAnnotations;

namespace myProjectMVC.Models
{
    public class City
    {
        [Key]
        public int cityID { get; set; }
        [Required]
        public string cityName { get; set; }
    }
}
