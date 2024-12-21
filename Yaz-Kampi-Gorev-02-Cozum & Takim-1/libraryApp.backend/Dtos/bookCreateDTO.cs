using libraryApp.backend.Entity;

namespace libraryApp.backend.Dtos
{
    public class bookCreateDTO
    {
        public string title { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;
        public int yazarId {get;set;}
    }
}
