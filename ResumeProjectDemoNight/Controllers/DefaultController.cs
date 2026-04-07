using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;
using System.Text.Json;

namespace ResumeProjectDemoNight.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ResumeContext _context;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public DefaultController(ResumeContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _httpClient = new HttpClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Message message, string website, string recaptchaToken)
        {
            // 🍯 Honeypot kontrolü - Bot tespiti
            if (!string.IsNullOrEmpty(website))
            {
                // Bot yakalandı - sessizce başarılı göster (botu kandır)
                TempData["Success"] = "Mesajınız gönderildi!";
                return Redirect("/#contact");
            }

            // 🔒 reCAPTCHA doğrulama
            var isValidCaptcha = await VerifyReCaptcha(recaptchaToken);
            if (!isValidCaptcha)
            {
                TempData["Error"] = "Güvenlik doğrulaması başarısız. Lütfen tekrar deneyin.";
                return Redirect("/#contact");
            }

            // ✅ Mesajı kaydet
            message.IsRead = false;
            message.SendDate = DateTime.Now;
            _context.Messages.Add(message);
            _context.SaveChanges();

            TempData["Success"] = "Mesajınız başarıyla gönderildi!";
            return Redirect("/#contact");
        }

        private async Task<bool> VerifyReCaptcha(string token)
        {
            if (string.IsNullOrEmpty(token))
                return false;

            try
            {
                var secretKey = _configuration["ReCaptcha:SecretKey"];
                var response = await _httpClient.GetStringAsync(
                    $"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={token}");

                var jsonDoc = JsonDocument.Parse(response);
                var root = jsonDoc.RootElement;

                var success = root.GetProperty("success").GetBoolean();
                var score = root.GetProperty("score").GetDouble();

                // Score 0.5'ten büyükse geçerli (0.0 = bot, 1.0 = insan)
                return success && score > 0.5;
            }
            catch
            {
                return false;
            }
        }
    }
}