using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;

namespace ResumeProjectDemoNight.Controllers
{
    public class TestController : Controller
    {
        private readonly ResumeContext _context;

        public TestController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = _context.Messages.Count();
            ViewBag.v2 = _context.Messages.Where(x => x.IsRead == true).Count();
            ViewBag.v3 = _context.Messages.Where(x => x.IsRead == false).Count();
            ViewBag.v4 = _context.Messages.Where(x => x.MessageId == 1).Select(y => y.NameSurname).FirstOrDefault();
            return View();
        }
    }
}
