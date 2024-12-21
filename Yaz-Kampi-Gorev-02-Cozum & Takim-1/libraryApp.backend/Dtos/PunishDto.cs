namespace libraryApp.backend.Dtos
{
    public class PunishDto
    {
        public int userId { get; set; }
        public int punisherId { get; set; }
        public bool isPunish { get; set; }
        public int fineAmount { get; set; }

    }
}
