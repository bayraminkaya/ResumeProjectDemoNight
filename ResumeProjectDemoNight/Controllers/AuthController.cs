using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using System.Security.Cryptography;
using System.Text;

namespace ResumeProjectDemoNight.Controllers
{
    public class AuthController : Controller
    {
        private readonly ResumeContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(ResumeContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: Login Page
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("AdminId") != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View();
        }

        // POST: Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                TempData["Error"] = "Kullanıcı adı ve şifre gereklidir.";
                return View();
            }

            var passwordHash = HashPassword(password);
            var admin = _context.Admins
                .FirstOrDefault(x => x.Username == username && x.PasswordHash == passwordHash && x.IsActive);

            if (admin == null)
            {
                TempData["Error"] = "Kullanıcı adı veya şifre hatalı.";
                return View();
            }

            HttpContext.Session.SetString("AdminId", admin.AdminId.ToString());
            HttpContext.Session.SetString("AdminUsername", admin.Username);
            HttpContext.Session.SetString("AdminFullName", admin.FullName ?? "Admin");
            HttpContext.Session.SetString("AdminProfileImage", admin.ProfileImage ?? "");

            admin.LastLoginDate = DateTime.Now;
            _context.SaveChanges();

            TempData["Success"] = "Başarıyla giriş yaptınız!";
            return RedirectToAction("Index", "Dashboard");
        }

        // GET: Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["Success"] = "Başarıyla çıkış yaptınız.";
            return RedirectToAction("Login");
        }

        // GET: Setup - CANLIDA KAPATILDI
        public IActionResult Setup()
        {
            // Güvenlik için kapatıldı
            return NotFound();

            
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