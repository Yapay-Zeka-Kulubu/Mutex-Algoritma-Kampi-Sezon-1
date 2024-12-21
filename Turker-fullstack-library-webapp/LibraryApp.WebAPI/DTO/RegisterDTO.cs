using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fullstack_library.DTO
{
    public class RegisterDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
    }
}