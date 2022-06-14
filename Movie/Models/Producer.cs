using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        public string Profilepictureurl { get; set; }
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Bigraphy")]
        public string Bio { get; set; }
        public List<Moviee> Movies { get; set; }
    }
}
