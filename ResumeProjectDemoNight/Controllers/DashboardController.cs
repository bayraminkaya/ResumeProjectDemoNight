using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeProjectDemoNight.Context;

namespace ResumeProjectDemoNight.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ResumeContext _context;

        public DashboardController(ResumeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            
            ViewBag.Statistics = _context.Statistics.Take(4).ToList();

            
            ViewBag.About = _context.Abouts.FirstOrDefault();

            
            ViewBag.TotalProjects = _context.Portfolios.Count();
            ViewBag.ActiveProjects = _context.Portfolios.Count(x => x.Status);
            ViewBag.TotalExperiences = _context.Experiences.Count();
            ViewBag.TotalSkills = _context.Skills.Count();
            ViewBag.TotalServices = _context.Services.Count();
            ViewBag.TotalTestimonials = _context.Testimonials.Count();
            ViewBag.TotalMessages = _context.Messages.Count();
            ViewBag.UnreadMessages = _context.Messages.Count(x => !x.IsRead);


            
            ViewBag.RecentProjects = _context.Portfolios
                .Include(x => x.Category)
                .OrderByDescending(x => x.PortfolioId)
                .Take(3)
                .ToList();

            
            ViewBag.Experiences = _context.Experiences
                .OrderByDescending(x => x.ExperienceId)
                .Take(3)
                .ToList();

            
            ViewBag.SocialMedias = _context.SocialMedias.ToList();

            
            ViewBag.TopSkills = _context.Skills
                .OrderByDescending(x => x.SkillName)
                .Take(6)
                .ToList();

            return View();
        }
    }
}
