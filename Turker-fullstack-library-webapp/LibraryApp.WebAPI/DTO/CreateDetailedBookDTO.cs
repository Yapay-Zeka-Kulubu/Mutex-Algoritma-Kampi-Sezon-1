using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.Data.Entity;

namespace fullstack_library.DTO
{
    public class CreateDetailedBookDTO
    {
        public int AuthorId { get; set; }
        public List<CreateDetailedBookPageDTO> Pages { get; set; } = new();
    }
}