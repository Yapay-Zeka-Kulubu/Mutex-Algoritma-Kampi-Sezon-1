namespace libraryApp.backend.Entity
{
    public class Punishment
    {
        public int id { get; set; }
        public int userId { get; set; }
        public DateOnly punishmentDate { get; set; }
        public bool isActive { get; set; }
        public int fineAmount { get; set; }

        public User? User { get; set; }
    }
}
