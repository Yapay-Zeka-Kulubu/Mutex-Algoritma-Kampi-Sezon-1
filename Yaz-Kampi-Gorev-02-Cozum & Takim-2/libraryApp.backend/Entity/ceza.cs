namespace libraryApp.backend.Entity;
public class ceza
{

    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime CezaGunu { get; set; }
    public DateTime CezaBitisGunu { get; set; }
    public bool CezaAktifMi { get; set; }


}