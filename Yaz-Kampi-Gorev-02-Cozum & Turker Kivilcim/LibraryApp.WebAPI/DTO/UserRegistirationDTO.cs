using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fullstack_library.DTO
{
    public class UserRegistirationDTO
    {
        public int UserId { get; set; }
        public bool IsApproved { get; set; }
        public int StaffId { get; set; }
    }
}