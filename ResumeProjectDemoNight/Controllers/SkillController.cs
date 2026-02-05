using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class SkillController : Controller
    {
        private readonly ResumeContext _context;

        public SkillController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult SkillList()
        {
            var skills = _context.Skills.ToList();
            return View(skills);
        }

        public IActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkill(Skill model)
        {
            if (ModelState.IsValid)
            {
                _context.Skills.Add(model);
                _context.SaveChanges();
                TempData["Success"] = "Yetenek başarıyla eklendi!";
                return RedirectToAction("SkillList");
            }
            TempData["Error"] = "Lütfen tüm alanları doğru şekilde doldurun.";
            return View(model);
        }

        public IActionResult UpdateSkill(int id)
        {
            var skill = _context.Skills.Find(id);
            if (skill == null)
            {
                TempData["Error"] = "Yetenek bulunamadı!";
                return RedirectToAction("SkillList");
            }
            return View(skill);
        }
        [HttpPost]
        public IActionResult UpdateSkill(Skill model)
        {
            if (ModelState.IsValid)
            {
                var skill = _context.Skills.Find(model.SkillId);
                if (skill != null)
                {
                    skill.SkillName = model.SkillName;
                    skill.SkillDegree = model.SkillDegree;
                    skill.SkillColor = model.SkillColor;
                    _context.SaveChanges();
                    TempData["Success"] = "Yetenek başarıyla güncellendi!";
                    return RedirectToAction("SkillList");
                }
            }
            TempData["Error"] = "Güncelleme sırasında bir hata oluştu.";
            return View(model);
        }
        public IActionResult DeleteSkill(int id)
        {
            var skill = _context.Skills.Find(id);
            if (skill != null)
            {
                _context.Skills.Remove(skill);
                _context.SaveChanges();
                TempData["Success"] = "Yetenek başarıyla silindi!";
            }
            else
            {
                TempData["Error"] = "Yetenek bulunamadı!";
            }
            return RedirectToAction("SkillList");
        }
    }
}