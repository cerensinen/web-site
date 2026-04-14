using Microsoft.AspNetCore.Mvc;
using ProjeninAdi.Models; // Kendi proje adını buraya yazmayı unutma!

namespace ProjeninAdi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IletisimController : ControllerBase
    {
        // Frontend'den POST isteği buraya gelecek
        [HttpPost]
        public IActionResult FormuAl([FromBody] IletisimFormu gelenForm)
        {
            // Şimdilik verinin gelip gelmediğini anlamak için konsola yazdıralım.
            // İleride buraya "mail atma" veya "veritabanına kaydetme" kodlarını yazacağız.
            Console.WriteLine($"--- YENİ MESAJ VAR! ---");
            Console.WriteLine($"Gönderen: {gelenForm.Isim}");
            Console.WriteLine($"E-Posta: {gelenForm.Email}");
            Console.WriteLine($"Mesaj: {gelenForm.Mesaj}");
            Console.WriteLine($"-----------------------");

            // Frontend'e "İşlem başarılı" cevabı (HTTP 200 OK) dönüyoruz.
            return Ok(new { mesaj = "Harika! Form verisi backend'e ulaştı." });
        }
    }
}