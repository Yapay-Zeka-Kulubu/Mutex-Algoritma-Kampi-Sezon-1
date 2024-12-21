using libraryApp.backend.Entity;

namespace libraryApp.backend.Dtos
{
    public class GetMessageDTO
    {
        public string title { get; set; } = string.Empty;
        public string content { get; set; } = string.Empty;
        public DateOnly sendingDate { get; set; }
        public bool isRead { get; set; }
        public string? senderName { get; set; }
    }
}
