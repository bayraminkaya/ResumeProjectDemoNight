using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class StatisticController : Controller
    {
        private readonly ResumeContext _context;

        public StatisticController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult StatisticList()
        {
            var values = _context.Statistics.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateStatistic()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateStatistic(Statistic statistic)
        {
            _context.Statistics.Add(statistic);
            _context.SaveChanges();
            TempData["Success"] = "İstatistik başarıyla eklendi!";
            return RedirectToAction("StatisticList");
        }

        public IActionResult DeleteStatistic(int id)
        {
            var value = _context.Statistics.Find(id);
            if (value != null)
            {
                _context.Statistics.Remove(value);
                _context.SaveChanges();
                TempData["Success"] = "İstatistik başarıyla silindi!";
            }
            return RedirectToAction("StatisticList");
        }

        [HttpGet]
        public IActionResult UpdateStatistic(int id)
        {
            var value = _context.Statistics.Find(id);
            if (value == null)
            {
                TempData["Error"] = "İstatistik bulunamadı!";
                return RedirectToAction("StatisticList");
            }
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateStatistic(Statistic statistic)
        {
            _context.Statistics.Update(statistic);
            _context.SaveChanges();
            TempData["Success"] = "İstatistik başarıyla güncellendi!";
            return RedirectToAction("StatisticList");
        }
    }
}