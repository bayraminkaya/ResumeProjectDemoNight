using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ResumeContext _context;

        public ServiceController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult ServiceList()
        {
            var values = _context.Services.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            TempData["Success"] = "Hizmet başarıyla eklendi!";
            return RedirectToAction("ServiceList");
        }

        public IActionResult DeleteService(int id)
        {
            var value = _context.Services.Find(id);
            if (value != null)
            {
                _context.Services.Remove(value);
                _context.SaveChanges();
                TempData["Success"] = "Hizmet başarıyla silindi!";
            }
            return RedirectToAction("ServiceList");
        }

        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var value = _context.Services.Find(id);
            if (value == null)
            {
                TempData["Error"] = "Hizmet bulunamadı!";
                return RedirectToAction("ServiceList");
            }
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            TempData["Success"] = "Hizmet başarıyla güncellendi!";
            return RedirectToAction("ServiceList");
        }
    }
}