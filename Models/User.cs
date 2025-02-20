using System.ComponentModel.DataAnnotations;

namespace Proiect_Final_TerescencoAlexandru.Models
{
    public class User
    {
        [Key]
        public int user_Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string image {  get; set; }
        public string Role { get; set; }

        public ICollection<Comment>? Comments { get; set; }
    }
}
