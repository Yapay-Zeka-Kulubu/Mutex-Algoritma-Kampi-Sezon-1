namespace libraryApp.backend.Entity;
public class kitap
{
    public int Id { get; set; }
    public string Isim { get; set; }
    public bool KitapYayinlandiMi { get; set; }
    public DateTime YayinlanmaTarihi { get; set; }

    public List<kitapYazari> kitapYazarlari { get; set; }
    public List<kitapYayinTalebi> kitapYayinTalepleri { get; set; }
    public List<kitapOdunc> kitapOduncIstekleri { get; set; }

    public List<sayfa> sayfalar { get; set; }

}