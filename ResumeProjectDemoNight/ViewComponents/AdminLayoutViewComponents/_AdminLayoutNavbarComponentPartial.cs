using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;

namespace ResumeProjectDemoNight.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutNavbarComponentPartial:ViewComponent
    {
        private readonly ResumeContext _context;

        public _AdminLayoutNavbarComponentPartial(ResumeContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            
            ViewBag.TotalProjects = _context.Portfolios.Count();

            
            ViewBag.UnreadMessageCount = _context.Messages.Count(x => !x.IsRead);

            
            ViewBag.UnreadMessages = _context.Messages
                .Where(x => !x.IsRead)
                .OrderByDescending(x => x.SendDate)
                .Take(5)
                .ToList();

            return View();
        }
    }
}
