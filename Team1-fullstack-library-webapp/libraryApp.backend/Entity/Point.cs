namespace libraryApp.backend.Entity
{
    public class Point
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int point { get; set; }
        public DateOnly earnDate { get; set; }

        public User? User { get; set; }
    }
}
