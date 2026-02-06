using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly ResumeContext _context;

        public PortfolioController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult PortfolioList()
        {
            var values = _context.Portfolios.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreatePortfolio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePortfolio(Portfolio portfolio)
        {
            
            portfolio.Description ??= "";
            portfolio.TechStack ??= "";
            portfolio.GithubUrl ??= "";
            portfolio.OtherImages ??= "";
            portfolio.Status = true;

            _context.Portfolios.Add(portfolio);
            _context.SaveChanges();
            TempData["Success"] = "Proje başarıyla eklendi!";
            return RedirectToAction("PortfolioList");
        }

        public IActionResult DeletePortfolio(int id)
        {
            var value = _context.Portfolios.Find(id);
            if (value != null)
            {
                _context.Portfolios.Remove(value);
                _context.SaveChanges();
                TempData["Success"] = "Proje başarıyla silindi!";
            }
            return RedirectToAction("PortfolioList");
        }

        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
            var value = _context.Portfolios.Find(id);
            if (value == null)
            {
                TempData["Error"] = "Proje bulunamadı!";
                return RedirectToAction("PortfolioList");
            }
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio portfolio)
        {
            
            portfolio.Description ??= "";
            portfolio.TechStack ??= "";
            portfolio.GithubUrl ??= "";
            portfolio.OtherImages ??= "";

            _context.Portfolios.Update(portfolio);
            _context.SaveChanges();
            TempData["Success"] = "Proje başarıyla güncellendi!";
            return RedirectToAction("PortfolioList");
        }
    }
}