using libraryApp.backend.Dtos;
using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace libraryApp.backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class MesajController : ControllerBase
    {
        private readonly ImesajRepository _mesajRepo;

        public MesajController(ImesajRepository mesajRepo)
        {
            _mesajRepo = mesajRepo;
        }

        [HttpGet("mesajAlmakutusu/{aliciId}")]
        public async Task<IActionResult> mesajAlmakutusu(int aliciId)
        {
            List<mesaj> mesajlar = await _mesajRepo.mesajlar.Where(mesaj => mesaj.AlanId == aliciId).Include(mesaj => mesaj.gonderen).ToListAsync();
            List<mesajdto> mesajdtolar = mesajlar.Select(mesaj => new mesajdto
            {
                MesajId = mesaj.Id,
                GonderenIsmi = mesaj.gonderen.Isim,
                baslik = mesaj.Konu,
                detaylar = mesaj.Icerik,
            }).ToList();

            return Ok(mesajdtolar);
        }

        [HttpPost("mesajOlustur")]
        public async Task<IActionResult> mesajOlustur([FromBody] mesajdto dto)
        {
            mesaj msj = new mesaj
            {
                AlanId = dto.alanId,
                GonderenId = dto.gonderenId,
                Icerik = dto.detaylar,
                Konu = dto.baslik,
            };
            await _mesajRepo.AddmesajAsync(msj);
            return Ok();
        }
    }
}