using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fullstack_library.DTO
{
    public class PageDTO
    {
        public int BookId { get; set; }
        public int PageId { get; set; }
        public int PageNumber { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}