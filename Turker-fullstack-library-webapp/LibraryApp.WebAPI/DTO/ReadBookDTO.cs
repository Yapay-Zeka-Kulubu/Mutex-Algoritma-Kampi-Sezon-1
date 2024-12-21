using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Entity;

namespace fullstack_library.DTO
{
    public class ReadBookDTO
    {
        public int BorrowedById { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsPublished { get; set; }
        public List<int> AuthorIds { get; set; } = new();
        public List<PageDTO> Pages { get; set; } = new();
    }
}