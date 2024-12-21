using System.ComponentModel.DataAnnotations.Schema;

namespace libraryApp.backend.Dtos
{
    public class kitapOduncIstekleridto
    {
        public int Id { get; set; }
        public string? isteyenKisiIsmi { get; set; }
        [Column(TypeName = "TARİH")]
        public DateTime talepTarihi { get; set; }
        [Column(TypeName = "TARİH")]
        public DateTime donusTarihi { get; set; }

        public string? kitapIsmi { get; set; }
    }
}
