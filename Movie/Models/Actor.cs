using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        [Required]
        [StringLength(50,MinimumLength =5)]
        public string Profilepictureurl { get; set; }
        [Display(Name = "Full Name")]
        [Required]

        public string FullName { get; set; }
        [Display(Name = "Biography")]
        [Required]

        public string Bio { get; set; }
        public List< Actor_Movie> Actors_Movies { get; set; }
    }
}
