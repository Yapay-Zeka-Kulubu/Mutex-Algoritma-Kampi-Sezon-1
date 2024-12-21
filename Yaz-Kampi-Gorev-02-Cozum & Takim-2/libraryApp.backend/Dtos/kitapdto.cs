namespace libraryApp.backend.Dtos
{
    public class kitapdto
    {
        public int Id { get; set; }
        public string kitapIsmi { get; set; } = string.Empty;
        public DateTime yayinlanmaTarihi { get; set; }
        public bool oduncAlindiMi { get; set; }
        public bool yayinlandiMi { get; set; }

        public List<string> kitapYazarlari { get; set; } = new();
    }
}
