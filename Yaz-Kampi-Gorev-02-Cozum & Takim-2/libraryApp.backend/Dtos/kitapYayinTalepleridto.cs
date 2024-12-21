using System.ComponentModel.DataAnnotations.Schema;

namespace libraryApp.backend.Dtos
{
    public class kitapYayinTalepleridto
    {
        public int Id { get; set; }
        public int kitapId { get; set; }
        public string kitapIsmi { get; set; } = string.Empty;
        public List<string> kitapYazarlari { get; set; } = new();
        [Column(TypeName = "DATE")]
        public DateTime talepTarihi { get; set; }
    }
}
