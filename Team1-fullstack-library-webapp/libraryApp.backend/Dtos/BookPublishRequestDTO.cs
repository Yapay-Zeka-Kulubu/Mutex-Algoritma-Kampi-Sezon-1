using libraryApp.backend.Entity;

namespace libraryApp.backend.Dtos
{
    public class BookPublishRequestDTO
    {
        public int id {get;set;}
        public int bookId {get;set;}
        public DateOnly requestDate { get; set; }
        public bool confirmation { get; set; } 
        public bool pending { get; set; }

        public string userFullname {get;set;}
        public string bookTitle {get;set;}
    }
}
