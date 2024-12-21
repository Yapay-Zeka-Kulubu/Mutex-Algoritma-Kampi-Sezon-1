using libraryApp.backend.Entity;

namespace libraryApp.backend.Dtos
{
    public class bookChangeTitleDTO
    {
        public int bookId {get;set;}
        public string yeniIsim {get;set;}
    }
}
