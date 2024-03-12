﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public bool Status { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public int LikeCount { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
