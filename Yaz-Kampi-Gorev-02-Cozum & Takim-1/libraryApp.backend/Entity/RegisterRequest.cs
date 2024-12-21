namespace libraryApp.backend.Entity
{
    public class RegisterRequest
    {
        public int id { get; set; }
        public int userId { get; set; }
        public DateOnly requestDate { get; set; }
        public bool confirmation { get; set; }
        public bool pending { get; set; }

        public User? User { get; set; }
    }
}
