using System.ComponentModel.DataAnnotations;

namespace myProjectMVC.Models
{
    public class Class
    {
        [Key]
        public int cityID { get; set; }
        [Required]
        public string cityName { get; set; }
    }
}
