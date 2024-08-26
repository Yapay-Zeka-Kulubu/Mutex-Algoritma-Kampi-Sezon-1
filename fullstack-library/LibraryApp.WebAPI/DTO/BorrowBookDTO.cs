using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fullstack_library.DTO
{
    public class BorrowBookDTO
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}