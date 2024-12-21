using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fullstack_library.DTO
{
    public class SetBorrowRequestDTO
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public bool IsApproved { get; set; }
        public string Details { get; set; } = string.Empty;
    }
}