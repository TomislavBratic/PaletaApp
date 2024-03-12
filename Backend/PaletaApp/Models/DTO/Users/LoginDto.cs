﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaletaApp.Models.DTO
{
    public class LoginDTO
    {
        [MaxLength(100)]
        [Required]
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
