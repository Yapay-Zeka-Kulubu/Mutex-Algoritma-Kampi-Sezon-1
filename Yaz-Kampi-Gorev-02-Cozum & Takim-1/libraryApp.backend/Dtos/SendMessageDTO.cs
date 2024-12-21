namespace libraryApp.backend.Dtos
{
    public class SendMessageDTO
    {
        public string title { get; set; } = string.Empty;
        public string content { get; set; } = string.Empty;
        public int senderId { get; set; }
        public int receiverId { get; set; }
    }
}
