using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaletaApp.Models.DTO
{
    public class ListUserDto
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string UserName { get; set; }
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
    }
}
