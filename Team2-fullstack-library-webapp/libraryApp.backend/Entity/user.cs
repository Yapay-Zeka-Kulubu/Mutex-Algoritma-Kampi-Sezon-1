namespace libraryApp.backend.Entity;
public class user
{
    public int Id { get; set; }
    public string Isim { get; set; }
    public string SoyIsim { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int RolId { get; set; }

    public rol rol { get; set; }
    public List<ceza> cezalar {get;set;}
    public List<hesapAcmaTalebi> hesapAcmaTalepleri {get;set;}
}