using libraryApp.backend.Dtos;
using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using libraryApp.backend.Repository.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace libraryApp.backend.Controllers
{
    [ApiController]// Bu sınıfın bir API (frontend ve backend arasındaki veri akışını sağlyan bir arayüz) kontrolcüsü olduğunu belirtiyor.
    [Route("api/[controller]")]// İsteklerin URL’de yönlendirileceği yolu  belirtir.
    public class KitapController : ControllerBase // ControllerBase sınıfından türetilir, API işlemleri için temel işlevsellik sağlar.
    {
        //beklemedeMi: kitap talebine cevap verildi mi?
        //onaylandiMi: kitap talabi onaylandı mı?
        //dondurulduMu: teslim edildi mi?

        //utcnow: evrensel zaman almaya yarar.

        // Burada, farklı repository (depo) interface'leri tanımlanıyor.
        //Kitap, sayfa, ödünç, kullanıcı, mesaj ve yayın talepleri depoları
        // Repository'ler, veri tabanının işleyeceği verileri içinde tutar.

        private readonly IkitapRepository _kitapRepo;
        private readonly IsayfaRepository _sayfaRepo;
        private readonly IkitapOduncRepository _kitapOduncRepo;
        private readonly IuserRepository _userRepo;
        private readonly ImesajRepository _mesajRepo;
        private readonly IkitapYayinTalebiRepository _kitapYayinTalebiRepo;
        private readonly IcezaRepository _cezaRepo;

        //controller'ın çalışabilmesi için ihtiyaç duyduğu repository'ler, constructor'a dışarıdan otomatik olarak aktarılır ve bu sayede controller içinde kullanılabilir hale gelir
        public KitapController(IcezaRepository cezaRepo, IkitapRepository kitapRepo, IkitapOduncRepository kitapOduncRepo, IuserRepository userRepo, IkitapYayinTalebiRepository kitapYayinTalebiRepository, IsayfaRepository sayfaRepository, ImesajRepository mesajRepository)
        {
            _kitapRepo = kitapRepo;
            _kitapOduncRepo = kitapOduncRepo;
            _userRepo = userRepo;
            _kitapYayinTalebiRepo = kitapYayinTalebiRepository;
            _sayfaRepo = sayfaRepository;
            _mesajRepo = mesajRepository;
            _cezaRepo = cezaRepo;
        }

        // Kitap yayınlama isteklerini getirir.
        [HttpGet("kitapYayinlamaİstekleri")]
        public async Task<IActionResult> kitapYayinlamaİstekleri() //kitap yayınlama isteklerini veritabanından alıp döderen method.
        {
            // Beklemede olan kitap yayınlama isteklerini, ilgili kitap ve yazar bilgileri ile birlikte alır.
            //await: programın eş zamanlı çalışabilmesi için gerekli bilgilerin gelmesini bekler.
            var kitapYayinlamaİstekleri = await _kitapYayinTalebiRepo.kitapYayinTalepleri.Where(kyt => kyt.BeklemedeMi).Include(kyt => kyt.kitap).ThenInclude(k => k.kitapYazarlari).ThenInclude(ky => ky.user).Where(kyt => !kyt.kitap.KitapYayinlandiMi).OrderBy(kyt => kyt.TalepTarihi).ToListAsync();

            return Ok(kitapYayinlamaİstekleri.Select(kyt => new kitapYayinTalepleridto
            {
                kitapYazarlari = kyt.kitap.kitapYazarlari.Select(ky => ky.user.Isim).ToList(),
                kitapIsmi = kyt.kitap.Isim,
                kitapId = kyt.KitapId,
                Id = kyt.Id,
                talepTarihi = kyt.TalepTarihi,
            }));
        }


        [HttpPost("yayinlamaIstegiAt")] //yazarın kitap yayınlama isteği atması
        public async Task<IActionResult> yayinlamaIstegiAt([FromBody] yayinTalebiDto yayinTalebi)
        {
            var kitap = await _kitapRepo.kitaplar.Include(k => k.kitapYazarlari).Include(k => k.kitapYayinTalepleri).FirstOrDefaultAsync(k => k.Id == yayinTalebi.kitapId); // Kitabı ID ile bulur.
            if (kitap == null) return NotFound(new { Message = "Kitap bulunamadı." }); // Kitap yoksa hata döner.
            if (kitap.kitapYayinTalepleri.Any(kyt => kyt.OnaylandiMi)) return BadRequest(new { Message = "Kitabın zaten yayınlandı." }); // Yayınlanmışsa hata döner.

            // Aynı kitaba ait bekleyen bir istek olup olmadığını kontrol eder.
            if (kitap.kitapYayinTalepleri.Any(kyt => kyt.BeklemedeMi))
                return NotFound(new { Message = "Aktif isteğin var." });

            // Yayınlama isteği oluşturur.
            await _kitapYayinTalebiRepo.AddkitapYayinTalebiAsync(new kitapYayinTalebi()
            {
                KitapId = yayinTalebi.kitapId,
                YazarId = yayinTalebi.yazarId,
                BeklemedeMi = true,
                TalepTarihi = DateTime.UtcNow,
            });
            return Ok(new { Message = "İstek gönderildi." });
        }


        [HttpGet("kitapArama")]

        public async Task<IActionResult> kitapArama([FromQuery] string? kitapIsmi) // Kitap ismine göre kitap araması yapar.
        {
            var kitaplar = await _kitapRepo.kitaplar.Where(k => k.Isim.Contains(kitapIsmi ?? "") && k.KitapYayinlandiMi).Take(20).Include(k => k.kitapOduncIstekleri).Select(k => new kitapdto
            {
                Id = k.Id,
                kitapIsmi = k.Isim,
                kitapYazarlari = k.kitapYazarlari.Select(ky => ky.user.Isim + " " + ky.user.SoyIsim).ToList(),
                oduncAlindiMi = k.kitapOduncIstekleri.Any(koi => koi.KitapId == k.Id && koi.BeklemedeMi == false && koi.OnaylandiMi && !koi.DondurulduMu),
                yayinlanmaTarihi = k.YayinlanmaTarihi,

            }).ToListAsync();
            return Ok(kitaplar);
        }
        [HttpGet("kitapOduncIstekleri")]



        public async Task<IActionResult> kitapOduncIstekleri()
        {

            var kitapOduncIstekleridto = await _kitapOduncRepo.kitapOduncler.Where(ko => ko.BeklemedeMi).Include(ko => ko.kitap).Include(ko => ko.user).OrderBy(ko => ko.TalepTarihi).Select(ko => new kitapOduncIstekleridto
            {
                Id = ko.Id,
                isteyenKisiIsmi = ko.user.Isim + " " + ko.user.SoyIsim,
                talepTarihi = ko.TalepTarihi,
                donusTarihi = ko.DonusTarihi,
                kitapIsmi = ko.kitap.Isim,
            }).ToListAsync();

            return Ok(kitapOduncIstekleridto);
        }


        [HttpPost("kitapOlustur")] //yazarın daha yayınlanmamış kitap oluşturması

        public async Task<IActionResult> kitapOlustur([FromBody] int yazarId)
        {
            if (!_userRepo.users.Any(u => u.Id == yazarId)) return NotFound(new { Message = "Yazar bulunamadı." });
            await _kitapRepo.AddkitapAsync(new kitap
            {
                Isim = "Yeni kitap",
                KitapYayinlandiMi = false,
                YayinlanmaTarihi = DateTime.MinValue,
                kitapYazarlari = [
                    new kitapYazari(){
                        UserId = yazarId,
                    }
                ]
            });
            return Ok(new { Message = "Kitap oluşturuldu" });
        }

        [HttpPut("kitapIsimDegis")]

        public async Task<IActionResult> kitapIsimDegis([FromBody] kitapIsmidto kitapIsmidto)
        {
            var kitap = await _kitapRepo.GetkitapByIdAsync(kitapIsmidto.kitapId);
            if (kitap == null) return NotFound();
            kitap.Isim = kitapIsmidto.yeniIsim;
            await _kitapRepo.UpdatekitapAsync(kitap);
            return Ok(new { Message = "Kitap ismi değişti" });
        }

        [HttpGet("oduncAlinanKitaplariGetir/{oduncAlanId}")]
        public async Task<IActionResult> oduncAlinanKitaplariGetir([FromRoute] int oduncAlanId)
        {
            var kitapoduncler = await _kitapOduncRepo.kitapOduncler.Where(ko => ko.UserId == oduncAlanId && ko.DondurulduMu == false && ko.OnaylandiMi == true).Include(ko => ko.kitap).ThenInclude(k => k.kitapYazarlari).ThenInclude(ky => ky.user).ToListAsync();
            var kitapdtos = kitapoduncler.Select(b => new kitapdto
            {
                Id = b.KitapId,
                kitapIsmi = b.kitap.Isim,
                yayinlanmaTarihi = b.kitap.YayinlanmaTarihi,
                kitapYazarlari = b.kitap.kitapYazarlari.Select(ky => ky.user.Isim).ToList(),
            });

            return Ok(kitapdtos);
        }

        [HttpGet("yazarinKitaplariniGetir/{yazarId}")]

        public async Task<IActionResult> yazarinKitaplariniGetir([FromRoute] int yazarId)
        {
            var kitaplar = await _kitapRepo.kitaplar.Include(k => k.kitapYazarlari).Include(k => k.kitapYayinTalepleri).Where(k => k.kitapYazarlari.Any(ky => ky.UserId == yazarId)).ToListAsync();

            var kitapdtos = kitaplar.Select(b => new kitapdto
            {
                Id = b.Id,
                kitapIsmi = b.Isim,
                yayinlanmaTarihi = b.YayinlanmaTarihi,
                yayinlandiMi = b.kitapYayinTalepleri.Any(kyt => kyt.OnaylandiMi)
            });

            return Ok(kitapdtos);

        }

        [HttpPost("sayfaEkle")]
        public async Task<IActionResult> sayfaEkle([FromBody] sayfa sf)
        {
            if (!_kitapRepo.kitaplar.Any(k => k.Id == sf.KitapId)) return NotFound();
            kitap? k = await _kitapRepo.kitaplar.Include(k => k.sayfalar).FirstOrDefaultAsync(k => k.Id == sf.KitapId);
            await _sayfaRepo.AddsayfaAsync(new sayfa
            {
                Icerik = sf.Icerik,
                SayfaNo = k!.sayfalar.Count + 1,
                KitapId = sf.KitapId,
            });
            return Ok();
        }

        [HttpPut("yayinlamaIstegineCevapVer")] //yazarın yayınlama isteğine görevli cevap verir
        public async Task<IActionResult> yayinlamaIstegineCevapVer([FromBody] yayinlamaIstegidto yayinIstekDto)
        {
            var yayinlamaIstegi = await _kitapYayinTalebiRepo.kitapYayinTalepleri.Include(kyt => kyt.kitap).FirstOrDefaultAsync(kyt => kyt.Id == yayinIstekDto.yayinIstekId && !kyt.kitap.KitapYayinlandiMi);
            if (yayinlamaIstegi == null) return NotFound();

            if(yayinIstekDto.OnaylandiMi) yayinlamaIstegi.kitap.YayinlanmaTarihi = DateTime.UtcNow;
            
            yayinlamaIstegi.OnaylandiMi = yayinIstekDto.OnaylandiMi;
            yayinlamaIstegi.BeklemedeMi = false;
            yayinlamaIstegi.kitap.KitapYayinlandiMi = yayinIstekDto.OnaylandiMi;
            await _kitapYayinTalebiRepo.UpdatekitapYayinTalebiAsync(yayinlamaIstegi);
            return Ok();
        }

        [HttpPut("kitapIadeEt")]
        public async Task<IActionResult> kitapIadeEt([FromBody] int kitapId)
        {
            var kitapOdunc = await _kitapOduncRepo.kitapOduncler.FirstOrDefaultAsync(ko => ko.KitapId == kitapId && ko.DondurulduMu == false && ko.OnaylandiMi);

            if (kitapOdunc == null) return NotFound();

            kitapOdunc.DondurulduMu = true;
            await _kitapOduncRepo.UpdatekitapOduncAsync(kitapOdunc);
            return Ok();
        }

        [HttpGet("kitapOku")]
        public async Task<IActionResult> kitapOku([FromQuery] int kitapId, [FromQuery] int isteyenId)
        {
            kitap? kitapp = await _kitapRepo.kitaplar.Include(k => k.sayfalar).Include(k => k.kitapYazarlari).Include(k => k.kitapOduncIstekleri).FirstOrDefaultAsync(k => k.Id == kitapId);
            
            if (kitapp == null) return NotFound();

            var userYoneticiMi = (await _userRepo.GetuserByIdAsync(isteyenId)).RolId == 4;
            var kitabinYazariMi = kitapp.kitapYazarlari.Any(ka => ka.UserId == isteyenId);
            var oduncAlindiMi = kitapp.kitapOduncIstekleri.Any(koi => koi.UserId == isteyenId && koi.OnaylandiMi && !koi.DondurulduMu);

            kitapOkudto okudto = new kitapOkudto
            {
                sayfalar = (userYoneticiMi || kitabinYazariMi || oduncAlindiMi) ? kitapp.sayfalar : kitapp.sayfalar.Take(3).ToList(),
                kitapIsmi = kitapp.Isim,
            };

            return Ok(okudto);
        }

        //register hesap istei atsın
        //kitap herkes okuyamasın
        //kitap isim değişsin

        [HttpPost("kitapOduncTalepEt")] //kitap ödünç istekleri
        public async Task<IActionResult> kitapOduncTalepEt([FromBody] kitapOduncTalebidto oduncTalebidto)
        {
            if (_kitapOduncRepo.kitapOduncler.Any(ko => !ko.DondurulduMu && ko.OnaylandiMi && ko.KitapId == oduncTalebidto.kitapId)) return BadRequest(new { message = "ewfwrfwr" });
            if (_kitapOduncRepo.kitapOduncler.Any(ko => ko.BeklemedeMi && ko.UserId == oduncTalebidto.isteyenId && ko.KitapId == oduncTalebidto.kitapId)) return BadRequest(new { message = "ergrtgt" });

            var ceza = await _cezaRepo.cezalar.FirstOrDefaultAsync(c => c.UserId == oduncTalebidto.isteyenId && c.CezaAktifMi);
            if (ceza != null)
            {
                if (ceza.CezaBitisGunu < DateTime.UtcNow)
                {
                    ceza.CezaAktifMi = false;
                    await _cezaRepo.UpdatecezaAsync(ceza);
                }
                return BadRequest(new { Message = "Kullanıcı cezalı" });
            }

            kitapOdunc kodunc = new kitapOdunc
            {
                BeklemedeMi = true,
                OnaylandiMi = false,
                DondurulduMu = false,
                TalepTarihi = DateTime.UtcNow,
                DonusTarihi = DateTime.UtcNow.AddDays(14),
                KitapId = oduncTalebidto.kitapId,
                UserId = oduncTalebidto.isteyenId,
            };
            await _kitapOduncRepo.AddkitapOduncAsync(kodunc);
            return Ok();
        }

        [HttpPut("gorevliOduncCevapVer")] //görevli ödünç kitap isteyenlere geri dönüş sağlıyor.
        public async Task<IActionResult> gorevliOduncCevapVer([FromBody] oduncCevapdto oduncdto)
        {
            kitapOdunc odunc = await _kitapOduncRepo.GetkitapOduncByIdAsync(oduncdto.oduncIstegiId);
            if (odunc == null) return NotFound();

            odunc.BeklemedeMi = false;
            odunc.OnaylandiMi = oduncdto.OnaylandiMi;
            await _kitapOduncRepo.UpdatekitapOduncAsync(odunc);


            if (oduncdto.OnaylandiMi)
            {
                var DigerIstekler = _kitapOduncRepo.kitapOduncler.Where(ko => ko.KitapId == odunc.KitapId && ko.BeklemedeMi && ko.Id != oduncdto.oduncIstegiId).ToList();
                foreach (var istek in DigerIstekler)
                {
                    istek.BeklemedeMi = false;
                    istek.OnaylandiMi = false;
                    await _kitapOduncRepo.UpdatekitapOduncAsync(istek);
                }
            }

            return Ok();
        }
    }



}

