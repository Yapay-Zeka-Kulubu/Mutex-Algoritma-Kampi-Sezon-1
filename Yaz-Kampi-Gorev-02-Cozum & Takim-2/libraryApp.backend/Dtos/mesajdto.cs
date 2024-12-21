namespace libraryApp.backend.Dtos
{
    public class mesajdto
    {
        public int? MesajId { get; set; }
        public string? GonderenIsmi { get; set; }
        public int gonderenId { get; set; }
        public int alanId { get; set; }
        public string baslik { get; set; } = string.Empty;
        public string detaylar { get; set; } = string.Empty;
        
    }
}
