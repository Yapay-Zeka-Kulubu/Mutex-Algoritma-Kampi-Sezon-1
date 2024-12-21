using libraryApp.backend.Entity;

namespace libraryApp.backend.Dtos
{
    public class BookSearchDTO
    {
        public int id { get; set; }
        public string title { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public int number_of_pages { get; set; }
        public bool isBookPublished { get; set; }
        public bool isBorrowed { get; set; }


        public List<string> BookAuthors { get; set; } = new();

    }
}
