using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fullstack_library.DTO
{
    public class MyBooksDTO
    {
        public int BookId { get; set; }
        public string BookName { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}