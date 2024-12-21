using System;
using System.Collections.Generic;
using System.Linq;

namespace libraryApp.backend.Dtos
{
    public class UserDto
    {
        public int id { get; set; }
        public int roleId { get; set; }
        public string roleName { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;
        public string surname { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public bool userStatus { get; set; }
        public int fineAmount { get; set; }


    }
}
