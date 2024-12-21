using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace libraryApp.backend.Controllers

{
    [ApiController] // Bu sınıfın bir API kontrolcüsü olduğunu belirtiyor.
    [Route("api/[controller]")]// İsteklerin URL’de "api/account" yoluna yönlendirileceğini belirtiyor.
    public class AccountController : ControllerBase
    {
        private readonly IuserRepository _userRepo; // kullanıcı veri tabanına ulaşabilmek için kullandık.
        private readonly IrolRepository _rolRepo;// rol veri tabanına ulaşabilmek için kullandık.
        private readonly IConfiguration _configuration;// Konfigürasyon verilerine (örn. JWT için gizli anahtar) erişim sağlamak için kullandık.

        private readonly IhesapAcmaTalebiRepository _hesapTalepRepo;

        public AccountController(IuserRepository userRepo, IrolRepository rolRepo, IConfiguration configuration, IhesapAcmaTalebiRepository hesapTalepRepo)
        {
            _userRepo = userRepo; // Kullanıcı deposunu dışarıdan alıyoruz.
            _rolRepo = rolRepo;   // Rol deposunu dışarıdan alıyoruz.
            _configuration = configuration;  // Konfigürasyon verilerini alıyoruz.
            _hesapTalepRepo = hesapTalepRepo;

        }
        [HttpPost("girisYap")]
        public async Task<IActionResult> girisYap(girisYapdto girisdto) //kullanıcı giriş fonksiyonu
        {
            // Veritabanında email'e göre kullanıcıyı ve kullanıcının rolünü kontrol eder.
            var user = await _userRepo.users.Include(u => u.hesapAcmaTalepleri).Include(u => u.rol).Where(u => u.hesapAcmaTalepleri.Any(hat => hat.OnaylandiMi)).FirstOrDefaultAsync(u => u.Email == girisdto.Email);
            if (user == null) return NotFound(new { message = "Kullanıcı bulunamadı." });// Kullanıcı bulunamazsa hata döndürür.
            if (!BCrypt.Net.BCrypt.Verify(girisdto.Password, user.Password)) return StatusCode(401, new { message = "Şifre doğru değil." });// Şifre kontrolü yapar. Şifre yanlışsa hata kodu 401 döndürür..

            // Kullanıcı bilgilerini bir DTO (Data Transfer Object) yapısına dönüştürür.
            userdto dto = new userdto
            {
                Id = user.Id,
                rolId = user.RolId,
                rolIsmi = user.rol.RolIsmi,
                Isim = user.Isim,
                SoyIsim = user.SoyIsim,
                Email = user.Email,
            };
            // JWT oluşturulur ve kullanıcıya geri döndürülür.
            string token = GenerateJWT(user);
            return Ok(new
            {
                userdto = dto,// Kullanıcı bilgileri
                token = token,//JWT(güvenli bilgi alışverişi için kullanılan bir standarttır.)
            });


        }
        // JWT (JSON Web Token) oluşturmak için kullanılan yardımcı fonksiyon.
        private string GenerateJWT(user us)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value ?? "");

            var tokenDescriptor = new SecurityTokenDescriptor // Token detayları ayarlanır.(kimlik doğrulama ve yetkilendirme işlemlerinde kullanılan küçük bir veri parçasıdır)
            {
                // JWT'ye kullanıcı bilgileri eklenir (örneğin rol ismi).
                Subject = new ClaimsIdentity([
                    new Claim("rolIsmi",us.rol.RolIsmi),
                ]),
                Expires = DateTime.UtcNow.AddDays(1),// Token süresi 1 gün olarak ayarlanır.
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),// Token şifreleme algoritması.
            };

            // Token oluşturulur ve yazdırılır.
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);




        }

        [HttpPost("KayitOl")]
        public async Task<IActionResult> KayitOl([FromBody] kayitOldto kayitdto) // Kullanıcı kayıt fonksiyonu.
        {
            if (_userRepo.users.Any(u => u.Email == kayitdto.Email)) return BadRequest("Email zaten kayıtlı."); // Email veritabanında zaten var mı kontrol edilir.

            // Yeni kullanıcı veritabanına eklenir.
            var user = new user
            {
                RolId = 1,
                Isim = kayitdto.Isim,
                SoyIsim = kayitdto.SoyIsim,
                Email = kayitdto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(kayitdto.Password), // Şifre hash'lenir.
            };
            await _userRepo.AdduserAsync(user);

            var talep = new hesapAcmaTalebi
            {
                UserId = user.Id,
                BeklemedeMi = true,
                OnaylandiMi = false,
                TalepTarihi = DateTime.UtcNow,
            };

            await _hesapTalepRepo.AddhesapAcmaTalebiAsync(talep);

            // Başarılı kayıt mesajı döndürülür.
            return Ok(new { message = "Kayıt gerçekleşti" });
        }

        [HttpGet("HesapAcmaTalepleriniGotruntule")]
        public async Task<IActionResult> HesapAcmaTalepleriniGoruntule()
        {

            var hesapAcmaTalebi = await _hesapTalepRepo.hesapAcmaTalepleri.Where(ht => ht.BeklemedeMi == true).Include(hat => hat.user).ToListAsync();
            var talepDtolar = hesapAcmaTalebi.Select(hat => new hesapAcmaTalebidto
            {
                Id = hat.Id,
                Email = hat.user.Email,
                Isim = hat.user.Isim,
                SoyIsim = hat.user.SoyIsim,
                TalepTarihi = hat.TalepTarihi
            });
            return Ok(talepDtolar);

        }

        [HttpPut("HesapAcmaTaleplerineYanıtVer")]
        public async Task<IActionResult> HesapAcmaTaleplerineYanıtVer([FromBody] hesapOnaydto hesapOnay)
        {
            var hesapAcmaTalebi = await _hesapTalepRepo.GethesapAcmaTalebiByIdAsync(hesapOnay.Id);
            if (hesapAcmaTalebi == null)
            {
                return NotFound();
            }
            else
            {
                hesapAcmaTalebi.BeklemedeMi = false;
                hesapAcmaTalebi.OnaylandiMi = hesapOnay.OnaylandiMi;
                await _hesapTalepRepo.UpdatehesapAcmaTalebiAsync(hesapAcmaTalebi);
                return Ok();
            }


        }
    }
}