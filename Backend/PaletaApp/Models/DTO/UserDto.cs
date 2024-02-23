using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaletaApp.Models.DTO
{
    public class UserDto
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<Blog> Blogs { get; set; } = new List<Blog>();
    }
}
