using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
namespace LibraryApp.Data.Entity
{
    public class BookPublishRequest
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        [Column(TypeName = "DATE")]
        public DateTime RequestDate { get; set; }
        public bool IsPending { get; set; }

        public Book Book { get; set; } = null!;
    }
}