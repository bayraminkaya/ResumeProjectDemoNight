using Microsoft.AspNetCore.Mvc;

namespace ResumeProjectDemoNight.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
