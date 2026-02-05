using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class AboutController : Controller
    {
        private readonly ResumeContext _context;

        public AboutController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult AboutList()
        {
            var about = _context.Abouts.FirstOrDefault();
            return View(about ?? new About());
        }

        [HttpPost]
        public IActionResult AboutList(About model)
        {
            if (ModelState.IsValid)
            {
                var existingAbout = _context.Abouts.FirstOrDefault();

                if (existingAbout != null)
                {
                    existingAbout.NameSurname = model.NameSurname;
                    existingAbout.ImageUrl = model.ImageUrl;
                    existingAbout.Description = model.Description;
                    existingAbout.Slider = model.Slider;
                    _context.SaveChanges();
                    TempData["Success"] = "Bilgileriniz başarıyla güncellendi!";
                }
                else
                {
                    _context.Abouts.Add(model);
                    _context.SaveChanges();
                    TempData["Success"] = "Bilgileriniz başarıyla kaydedildi!";
                }

                return RedirectToAction("AboutList");
            }

            TempData["Error"] = "Lütfen tüm alanları doğru şekilde doldurun.";
            return View(model);
        }
    }
}