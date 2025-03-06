using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proiect_Final_TerescencoAlexandru.Models
{
    public class Screenshot
    {
        [Key]
        public int screenshot_Id { get; set; }
        public string image_1 { get; set; }
        public string image_2 { get; set; }
        public string image_3 { get; set; }
        public string image_4 { get; set; }
        public string image_5 { get; set; }
        public string image_6 { get; set; }
        public string image_7 { get; set; }
        public string image_8 { get; set; }
        public string image_9 { get; set; }
        public string image_10 { get; set; }
        [ForeignKey("GameId")]
        public Game? Game { get; set; }
        public int GameId { get; set; }
    }
}
