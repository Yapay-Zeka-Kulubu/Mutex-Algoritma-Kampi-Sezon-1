namespace libraryApp.backend.Entity;
public class kitapYazari
{
    public int Id { get; set; }
    public int KitapId { get; set; }
    public int UserId { get; set; }

    public user user { get; set; }
    public kitap kitap { get; set; }
}