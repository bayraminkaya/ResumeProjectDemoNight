using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectDemoNight.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
