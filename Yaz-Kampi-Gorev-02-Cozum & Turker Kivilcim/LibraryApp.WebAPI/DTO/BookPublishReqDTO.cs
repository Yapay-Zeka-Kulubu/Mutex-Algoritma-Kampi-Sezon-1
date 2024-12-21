using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fullstack_library.DTO
{
    public class BookPublishReqDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; } = string.Empty;
        public List<string> Authors { get; set; } = new();
        [Column(TypeName = "DATE")]
        public DateTime RequestDate { get; set; }
    }
}