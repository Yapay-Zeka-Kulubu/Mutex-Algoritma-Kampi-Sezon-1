namespace libraryApp.backend.Entity;
public class kitapOdunc
{
    public int Id { get; set; }
    public int KitapId { get; set; }
    public int UserId { get; set; }
    public DateTime TalepTarihi { get; set; }
    public DateTime DonusTarihi { get; set; }
    public bool OnaylandiMi { get; set; }
    public bool BeklemedeMi { get; set; }
    public bool DondurulduMu { get; set; }

    public kitap kitap { get; set; }
    public user user { get; set; }
}