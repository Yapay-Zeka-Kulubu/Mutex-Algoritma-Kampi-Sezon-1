namespace libraryApp.backend.Entity;
public class kitapYayinTalebi
{
    public int Id { get; set; }
    public int KitapId { get; set; }
    public int YazarId { get; set; }
    public DateTime TalepTarihi { get; set; }
    public bool OnaylandiMi { get; set; }
    public bool BeklemedeMi { get; set; }

    public kitap kitap { get; set; }
    public user yazar { get; set; }
}