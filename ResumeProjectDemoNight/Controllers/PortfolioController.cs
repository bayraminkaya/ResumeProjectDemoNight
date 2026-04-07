using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            // Sıralama eklendi
            var values = _context.Portfolios
                .Include(x => x.Category)
                .OrderBy(x => x.DisplayOrder)
                .ThenByDescending(x => x.PortfolioId)
                .ToList();
            ViewBag.Categories = _context.Categories.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreatePortfolio()
        {
            ViewBag.Categories = _context.Categories.ToList();
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
            // DisplayOrder zaten formdan geliyor, default 0

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
            ViewBag.Categories = _context.Categories.ToList();
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdatePortfolio(Portfolio portfolio)
        {
            portfolio.Description ??= "";
            portfolio.TechStack ??= "";
            portfolio.GithubUrl ??= "";
            portfolio.OtherImages ??= "";
            // DisplayOrder formdan geliyor

            _context.Portfolios.Update(portfolio);
            _context.SaveChanges();
            TempData["Success"] = "Proje başarıyla güncellendi!";
            return RedirectToAction("PortfolioList");
        }

        [HttpPost]
        public IActionResult CreateCategory(string categoryName)
        {
            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                var category = new Category { CategoryName = categoryName.Trim() };
                _context.Categories.Add(category);
                _context.SaveChanges();
                TempData["Success"] = "Kategori başarıyla eklendi!";
            }
            return RedirectToAction("PortfolioList");
        }

        [HttpPost]
        public IActionResult UpdateCategory(int categoryId, string categoryName)
        {
            var category = _context.Categories.Find(categoryId);
            if (category != null && !string.IsNullOrWhiteSpace(categoryName))
            {
                category.CategoryName = categoryName.Trim();
                _context.SaveChanges();
                TempData["Success"] = "Kategori başarıyla güncellendi!";
            }
            return RedirectToAction("PortfolioList");
        }

        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                var hasPortfolios = _context.Portfolios.Any(p => p.CategoryId == id);
                if (hasPortfolios)
                {
                    TempData["Error"] = "Bu kategoride projeler var! Önce projeleri başka kategoriye taşıyın.";
                }
                else
                {
                    _context.Categories.Remove(category);
                    _context.SaveChanges();
                    TempData["Success"] = "Kategori başarıyla silindi!";
                }
            }
            return RedirectToAction("PortfolioList");
        }
    }
}