namespace LibraryApp.Data.Entity
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<User> Users { get; set; } = new();
    }
}