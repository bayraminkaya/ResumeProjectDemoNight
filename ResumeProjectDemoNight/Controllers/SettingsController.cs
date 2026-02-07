using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using System.Security.Cryptography;
using System.Text;

namespace ResumeProjectDemoNight.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ResumeContext _context;
        private readonly IConfiguration _configuration;

        public SettingsController(ResumeContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: Ayarlar Sayfası
        public IActionResult Index()
        {
            var adminId = HttpContext.Session.GetString("AdminId");
            if (string.IsNullOrEmpty(adminId))
            {
                return RedirectToAction("Login", "Auth");
            }

            var admin = _context.Admins.Find(int.Parse(adminId));
            if (admin == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            ViewBag.Admin = admin;
            return View();
        }

        // POST: Şifre Değiştir
        [HttpPost]
        public IActionResult ChangePassword(string currentPassword, string newPassword, string confirmPassword)
        {
            var adminId = HttpContext.Session.GetString("AdminId");
            if (string.IsNullOrEmpty(adminId))
            {
                return RedirectToAction("Login", "Auth");
            }

            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                TempData["Error"] = "Tüm alanları doldurunuz.";
                return RedirectToAction("Index");
            }

            if (newPassword != confirmPassword)
            {
                TempData["Error"] = "Yeni şifreler eşleşmiyor.";
                return RedirectToAction("Index");
            }

            if (newPassword.Length < 6)
            {
                TempData["Error"] = "Yeni şifre en az 6 karakter olmalıdır.";
                return RedirectToAction("Index");
            }

            var admin = _context.Admins.Find(int.Parse(adminId));
            if (admin == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var currentPasswordHash = HashPassword(currentPassword);
            if (admin.PasswordHash != currentPasswordHash)
            {
                TempData["Error"] = "Mevcut şifre hatalı.";
                return RedirectToAction("Index");
            }

            admin.PasswordHash = HashPassword(newPassword);
            _context.SaveChanges();

            TempData["Success"] = "Şifreniz başarıyla değiştirildi.";
            return RedirectToAction("Index");
        }

        // POST: Profil Güncelle
        [HttpPost]
        public IActionResult UpdateProfile(string fullName, string email, string profileImage)
        {
            var adminId = HttpContext.Session.GetString("AdminId");
            if (string.IsNullOrEmpty(adminId))
            {
                return RedirectToAction("Login", "Auth");
            }

            var admin = _context.Admins.Find(int.Parse(adminId));
            if (admin == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            admin.FullName = fullName;
            admin.Email = email;
            admin.ProfileImage = profileImage;
            _context.SaveChanges();

            HttpContext.Session.SetString("AdminFullName", fullName ?? "Admin");
            HttpContext.Session.SetString("AdminProfileImage", profileImage ?? "");

            TempData["Success"] = "Profil bilgileriniz güncellendi.";
            return RedirectToAction("Index");
        }

        // Şifre hashleme - Salt'ı appsettings'den al
        private string HashPassword(string password)
        {
            var salt = _configuration["SecuritySettings:PasswordSalt"] ?? "DefaultSaltValue2024";

            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password + salt));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}