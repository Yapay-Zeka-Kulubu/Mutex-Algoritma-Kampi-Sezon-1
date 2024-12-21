namespace libraryApp.backend.Entity
{

    public class mesaj
    {
        public int Id { get; set; }
        public int GonderenId { get; set; }
        public int AlanId { get; set; }
        public string Konu { get; set; }
        public string Icerik { get; set; }

        public user gonderen { get; set; }
    }
}