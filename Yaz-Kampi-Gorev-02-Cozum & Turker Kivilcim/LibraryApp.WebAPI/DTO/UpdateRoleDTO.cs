using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fullstack_library.DTO
{
    public class UpdateRoleDTO
    {
        public int UserId { get; set; }
        public int NewRoleId { get; set; }
    }
}