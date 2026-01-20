using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectDemoNight.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
