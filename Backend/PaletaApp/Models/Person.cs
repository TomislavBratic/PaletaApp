using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaletaApp.Models
{
   public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string  LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<Blog> Blogs { get; set; } = new List<Blog>();
    }
}
