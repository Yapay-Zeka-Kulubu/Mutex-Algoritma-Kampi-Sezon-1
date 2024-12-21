using libraryApp.backend.Dtos;
using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using static System.Net.WebRequestMethods;



namespace libraryApp.backend.Controllers

{
    [ApiController] // Bu sınıfın bir API controller (frontend ve backend arasındaki veri akışını sağlayan bir arayüz) olduğunu belirttik. Böylece, bu sınıf gelen HTTP isteklerini işleyebilir.
    [Route("api/[controller]")] // API'nin URL'deki rotasının "api/UserController" olduğunu gösterdik.
    public class UserController : ControllerBase
    {
        // Gerekli repository'leri (veritabanı işlemleri için kullanacaklarımızı) private alanlar olarak tanımladık.
        //Bağımlılık enjeksiyonu(Dependency Injection) (uygulamanın çalışması için gerekli dış bileşenler)ile bu repository'ler otomatik olarak controller'a dışarıdan sağlanacak, böylece sınıf içindeki veritabanı işlemlerinde kullanabileceğiz.
        private readonly IuserRepository _userRepo;
        private readonly IrolRepository _rolRepo;

        private readonly IcezaRepository _cezaRepo;
        private readonly ImesajRepository _mesajRepo;

        // Constructor aracılığıyla bağımlılıkları (userRepo, rolRepo, cezaRepo) sınıfa aktardık.
        // Constructer:
        public UserController(IuserRepository userRepo, IrolRepository rolRepo, IcezaRepository cezaRepo, ImesajRepository mesajRepo)
        {
            _userRepo = userRepo; // userRepo'yu sınıf içinde kullanmak için _userRepo'ya atadık.(user veri tabanına ulaşabilmek için)
            _rolRepo = rolRepo; // rolRepo'yu sınıf içinde kullanmak için _rolRepo'ya atadık.
            _cezaRepo = cezaRepo; // cezaRepo'yu sınıf içinde kullanmak için _cezaRepo'ya atadık.
            _mesajRepo = mesajRepo;
        }
        [HttpGet("rolleriGetir")] // HTTP GET isteği ile "rolleriGetir" metoduna ulaşılacağını belirttik.
        public async Task<IActionResult> rolleriGetir() // rolleri veritabanından alıp dönderen bir method.
        {
            var roller = await _rolRepo.roller.ToListAsync(); // rolRepo'daki roller listesini veritabanından çekeriz.
            return Ok(roller); // Alınan roller listesini döndürür.
        }

        [HttpPut("roluGuncelle")] // HTTP PUT isteği ile "roluGuncelle" metoduna ulaşılacağını belirttik.
        public async Task<IActionResult> rolleriDegistir([FromBody] rolDegistirmedto rolDegistirdto) // rol değiştirme işlemini yapan method.
        {
            var user = await _userRepo.GetuserByIdAsync(rolDegistirdto.userId); // Gönderilen userId ile kullanıcıyı veritabanından buluruz.
            if (user == null) // Eğer kullanıcı bulunamazsa
            {
                return NotFound(); // Kullanıcı bulunamadı hatası döndürülür (HTTP 404 Not Found).
            }
            else
            {
                user.RolId = rolDegistirdto.yeniRolId; // Kullanıcının rolü değiştirdik.
                await _userRepo.UpdateuserAsync(user); // Değişiklikler veritabanına kaydettik.
                return Ok(); // Başarılı bir şekilde güncellendi bilgisi döndürülür.
            }
        }
        [HttpGet("rolDegistirilecekUserlariGetir/{rolId}")] // HTTP GET isteği ile "rolDegistirilecekUserlariGetir" metoduna ulaşılacağını belirttik.
        public async Task<IActionResult> rolUserGetir(int rolId) // Rolü değiştirilebilecek kullanıcıları getiren method.
        {
            List<user> userlar = await _userRepo.users.Where(user => user.RolId < rolId).Include(user => user.rol).Include(u => u.hesapAcmaTalepleri).Where(u => u.hesapAcmaTalepleri.Any(hat => hat.OnaylandiMi)).ToListAsync(); // RollId'si 4'ten küçük olan kullanıcıları (kısıtlı roller) ve onlara ait rolleri veritabanından çektik.

            List<rolUserGetirdto> userGetirdtolar = userlar.Select(user => new rolUserGetirdto // Kullanıcıları DTO'ya dönüştürürüz.
            {
                Isım = user.Isim, // Kullanıcının ismi.
                rolIsmi = user.rol.RolIsmi, // Kullanıcının rolünün ismi.
                Soyisim = user.SoyIsim, // Kullanıcının soyismi.
                userId = user.Id, // Kullanıcının ID'si.
            }).ToList();

            return Ok(userGetirdtolar); // DTO'ya dönüştürülen kullanıcıları döndürürüz.
        }

        [HttpGet("cezaVerilebilecekUserlariGetir/{rolId}")] // HTTP GET isteği ile "cezaVerilebilecekUserlariGetir" metoduna ulaşılacağını belirttik.
        public async Task<IActionResult> cezaUserGetir([FromRoute] int rolId) // Ceza verilebilecek kullanıcıları getiren method.
        {
            var users = await _userRepo.users.Where(u => u.RolId < rolId).Include(u => u.rol).Include(u => u.cezalar).Include(u => u.hesapAcmaTalepleri).Where(u => u.hesapAcmaTalepleri.Any(hat => hat.OnaylandiMi)).ToListAsync();  // rolId'den küçük rollere sahip kullanıcıları ve onlara ait rolleri veritabanından çekeriz.
            var userGetirdtolar = users.Select(u => new rolUserGetirdto // Kullanıcıları DTO'ya dönüştürürüz.
            {
                Isım = u.Isim, // Kullanıcının ismi.
                rolIsmi = u.rol.RolIsmi, // Kullanıcının rolünün ismi.
                Soyisim = u.SoyIsim, // Kullanıcının soyismi.
                userId = u.Id, // Kullanıcının ID'si.
                cezaliMi = u.cezalar.Any(c => c.UserId == u.Id && c.CezaAktifMi == true),
            }).ToList();

            return Ok(userGetirdtolar); // DTO'ya dönüştürülen kullanıcıları döndürürüz.
        }

        [HttpPost("cezaVer")] // HTTP POST isteği ile "cezaVer" metoduna ulaşılacağını belirttik.
        public async Task<IActionResult> cezaVer([FromBody] cezaVerdto cezaVer) // Ceza verme işlemini yapan method.
        {
            var user = await _userRepo.GetuserByIdAsync(cezaVer.userId); // Verilen userId ile kullanıcıyı veritabanından buluruz.
            if (user == null) // Eğer kullanıcı bulunamazsa
            {
                return NotFound(); // Kullanıcı bulunamadı hatası döndürülür (HTTP 404 Not Found).
            }
            else
            {
                var ceza = new ceza // Yeni ceza kaydı oluştururuz.
                {
                    UserId = cezaVer.userId, // Cezanın kullanıcısının ID'si.
                    CezaAktifMi = true, // Ceza aktif olarak işaretlenir.
                    CezaBitisGunu = DateTime.UtcNow.AddDays(5), // Cezanın bitiş tarihi(14 gün sonra).
                    CezaGunu = DateTime.UtcNow, // Cezanın başlama tarihi (şu anki zaman).
                };
                await _cezaRepo.AddcezaAsync(ceza); // Yeni ceza kaydı veritabanına eklenir.

                await _mesajRepo.AddmesajAsync(new mesaj{
                    AlanId = cezaVer.userId,
                    GonderenId = cezaVer.cezaVerenId,
                    Konu = cezaVer.mesajBaslik,
                    Icerik = cezaVer.mesajIcerik,
                });
                
                return Ok(); // Ceza başarıyla eklendi bilgisi döndürülür.
            }

        }

        [HttpPut("cezaKaldir")] // HTTP PUT isteği ile "cezaKaldir" metoduna ulaşılacağını belirttik.
        public async Task<IActionResult> cezaKaldir([FromBody] int userId) // Ceza kaldırma işlemini yapan method.
        {
            var cezaKaydi = await _cezaRepo.cezalar.Where(c => c.UserId == userId && c.CezaAktifMi == true).FirstOrDefaultAsync(); // Verilen userId ile aktif cezayı buluruz.
            if (cezaKaydi == null) // Eğer aktif ceza kaydı bulunamazsa
            {
                return NotFound(); // Ceza bulunamadı hatası döndürülür (HTTP 404 Not Found).
            }
            else
            {
                cezaKaydi.CezaAktifMi = false; // Ceza pasif duruma getirilir.
                await _cezaRepo.UpdatecezaAsync(cezaKaydi); // Ceza güncellenir ve veritabanına kaydedilir.
                return Ok(); // Ceza başarıyla kaldırıldı bilgisi döndürülür.
            }
        }
        [HttpGet("mesajGonderilebilecekUserlarGetir/{rolId}")] // HTTP GET isteği ile "mesajGonderilebilecekUserlarGetir" metoduna ulaşılacağını belirttik.
        public async Task<IActionResult> mesajGonderilebilecekUserlarGetir([FromRoute] int rolId) // Mesaj gönderilebilecek kullanıcıları getiren method.
        {
            // Mesaj gönderilebilecek roller belirlenir. Rol ID'ye göre mesaj gönderilebilecek roller listeye eklenir.
            //1-user 2-yazar 3-gorevli 4-yonetici 
            var roller = new List<int>();

            if (rolId == 1) // Eğer kullanıcı rolId'si 1 (user) ise, sadece 3 numaralı role (görevli) mesaj gönderebilir.
            {
                roller.Add(3);
            }
            else if (rolId == 2) // Eğer rolId 2 (yazar) ise, 3 ve 4 numaralı rollere (görevli ve yönetici) mesaj gönderebilir.
            {
                roller.Add(3);
                roller.Add(4);
            }
            else if (rolId == 3) // Eğer rolId 3 (görevli) ise, 1, 2 ve 4 numaralı rollere mesaj gönderebilir.
            {
                roller.Add(1);
                roller.Add(2);
                roller.Add(4);
            }
            else if (rolId == 4) // Eğer rolId 4 (yönetici) ise, 2 ve 3 numaralı rollere mesaj gönderebilir.
            {
                roller.Add(2);
                roller.Add(3);
            }

            var users = await _userRepo.users.Where(u => roller.Contains(u.RolId)).Include(u => u.rol).Include(u => u.hesapAcmaTalepleri).Where(u => u.hesapAcmaTalepleri.Any(hat => hat.OnaylandiMi)).ToListAsync(); // Yukarıda belirlenen rollerle eşleşen kullanıcıları ve onların rollerini veritabanından çekeriz.
            var userGetirdtolar = users.Select(u => new rolUserGetirdto // Kullanıcıları DTO'ya dönüştürürüz.
            {
                Isım = u.Isim, // Kullanıcının ismi.
                rolIsmi = u.rol.RolIsmi, // Kullanıcının rolünün ismi.
                Soyisim = u.SoyIsim, // Kullanıcının soyismi.
                userId = u.Id, // Kullanıcının ID'si.

            }).ToList();
            return Ok(userGetirdtolar); // DTO'ya dönüştürülen kullanıcılar başarılı bir şekilde döndürülür.


        }







    }

}





