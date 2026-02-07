using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class CertificateController : Controller
    {
        private readonly ResumeContext _context;

        public CertificateController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult CertificateList()
        {
            var certificates = _context.Certificates.OrderByDescending(x => x.CertificateId).ToList();
            return View(certificates);
        }

        [HttpGet]
        public IActionResult CreateCertificate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCertificate(Certificate certificate)
        {
            _context.Certificates.Add(certificate);
            _context.SaveChanges();
            return RedirectToAction("CertificateList");
        }

        [HttpGet]
        public IActionResult UpdateCertificate(int id)
        {
            var certificate = _context.Certificates.Find(id);
            if (certificate == null) return NotFound();
            return View(certificate);
        }

        [HttpPost]
        public IActionResult UpdateCertificate(Certificate certificate)
        {
            var existing = _context.Certificates.Find(certificate.CertificateId);
            if (existing == null) return NotFound();

            existing.Name = certificate.Name;
            existing.Issuer = certificate.Issuer;
            existing.IssueDate = certificate.IssueDate;
            existing.CredentialUrl = certificate.CredentialUrl;
            existing.IconUrl = certificate.IconUrl;
            existing.Status = certificate.Status;

            _context.SaveChanges();
            return RedirectToAction("CertificateList");
        }

        public IActionResult DeleteCertificate(int id)
        {
            var certificate = _context.Certificates.Find(id);
            if (certificate != null)
            {
                _context.Certificates.Remove(certificate);
                _context.SaveChanges();
            }
            return RedirectToAction("CertificateList");
        }
    }
}