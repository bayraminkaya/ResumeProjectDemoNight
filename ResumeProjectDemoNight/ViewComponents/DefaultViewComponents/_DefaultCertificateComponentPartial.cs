using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;

namespace ResumeProjectDemoNight.ViewComponents.DefaultViewComponents
{
    public class _DefaultCertificateComponentPartial:ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultCertificateComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var certificates = _context.Certificates
                .Where(x => x.Status)
                .OrderByDescending(x => x.CertificateId)
                .ToList();
            return View(certificates);
        }
    }
}
