using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fullstack_library.DTO
{
    public class StaffOfMonthDTO
    {
        public UserDTO StaffOfPrevMonth { get; set; } = null!;
        public List<UserDTO> CurrentTop3Staff { get; set; } = new();
    }
}