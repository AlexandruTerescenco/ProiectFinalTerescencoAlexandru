﻿using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Proiect_Final_TerescencoAlexandru.Models
{
    public class Game
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Image { get; set; }
        [Required]
        public string Review { get; set; }
        public string Reviewer { get; set; }
        [Required]
        public float Score { get; set; }
        public Comment? Comment { get; set; }
        public int screenshot_id { get; set; }
        public Screenshot Screenshot { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Screenshot>? Screenshots { get; set; }
    }
}
