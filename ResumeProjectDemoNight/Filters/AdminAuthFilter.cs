using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ResumeProjectDemoNight.Filters
{
    public class AdminAuthFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var session = context.HttpContext.Session;
            var adminId = session.GetString("AdminId");

            // Auth controller'a izin ver
            var controller = context.RouteData.Values["controller"]?.ToString()?.ToLower();
            var action = context.RouteData.Values["action"]?.ToString()?.ToLower();

            // Public controller'lar (login gerektirmeyen)
            var publicControllers = new[] { "auth", "home", "default" };
            var publicActions = new[] { "login", "setup", "index" };

            if (publicControllers.Contains(controller))
            {
                return; // İzin ver
            }

            // Admin girişi yoksa login'e yönlendir
            if (string.IsNullOrEmpty(adminId))
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Sonrası için bir işlem yok
        }
    }
}