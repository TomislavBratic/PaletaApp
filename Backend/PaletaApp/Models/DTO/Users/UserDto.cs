using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaletaApp.Models.DTO
{
    public class UserDto
    {
        [MaxLength(100)]
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Token { get; set; }
     
    }
}
