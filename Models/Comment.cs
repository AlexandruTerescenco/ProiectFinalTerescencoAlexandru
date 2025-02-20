using System.ComponentModel.DataAnnotations;

namespace Proiect_Final_TerescencoAlexandru.Models
{
    public class Comment
    {
        [Key]
        public int comment_Id { get; set; }
        [Required]
        public string comment_text { get; set; }
        public DateTime PostedOn { get; set; }
        public int user_Id { get; set; }
        public User? User { get; set; }
        public int game_Id { get; set; }
        public Game? Game { get; set; }
    }
}
