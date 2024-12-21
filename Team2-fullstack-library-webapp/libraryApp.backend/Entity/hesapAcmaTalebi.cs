namespace libraryApp.backend.Entity;
public class hesapAcmaTalebi
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime TalepTarihi { get; set; }
    public bool OnaylandiMi { get; set; }
    public bool BeklemedeMi { get; set; }

    public user user {get;set;}
}