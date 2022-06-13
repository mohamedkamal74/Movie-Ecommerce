using System.ComponentModel.DataAnnotations;

namespace Movie.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        public string Profilepictureurl { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
    }
}
