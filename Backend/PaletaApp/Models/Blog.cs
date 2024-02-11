using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaletaApp.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }
        [Required]
        [MaxLength(50)]
        public  bool Status { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public int LikeCount { get; set; }

    }
}
