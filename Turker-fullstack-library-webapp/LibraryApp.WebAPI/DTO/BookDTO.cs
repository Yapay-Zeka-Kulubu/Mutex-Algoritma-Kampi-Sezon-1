using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Entity;

namespace fullstack_library.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime PublishDate { get; set; }
        public bool IsBorrowed { get; set; }

        public List<string> Authors { get; set; } = new();
    }
}