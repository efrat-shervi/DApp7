using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class registerDto
    {
        [Required]
        public string username;
        [Required]
        public string password;
    }
}