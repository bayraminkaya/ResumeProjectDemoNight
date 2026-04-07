using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;

namespace ResumeProjectDemoNight.ViewComponents.DefaultViewComponents
{
    public class _DefaultPortfolioComponentPartial:ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultPortfolioComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var portfolios = _context.Portfolios
                .Where(x => x.Status == true)
                .OrderBy(x => x.DisplayOrder)  // Önce DisplayOrder'a göre
                .ThenByDescending(x => x.PortfolioId)  // Sonra ID'ye göre (yeni önce)
                .ToList();

            return View(portfolios);
        }
    }
}
