using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectDemoNight.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
