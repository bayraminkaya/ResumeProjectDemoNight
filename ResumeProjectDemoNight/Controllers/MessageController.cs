using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;

namespace ResumeProjectDemoNight.Controllers
{
    public class MessageController : Controller
    {
        private readonly ResumeContext _context;

        public MessageController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult MessageList()
        {
            var values = _context.Messages.OrderByDescending(x => x.SendDate).ToList();
            return View(values);
        }

        public IActionResult MessageDetails(int id)
        {
            var value = _context.Messages.Find(id);
            if (value == null)
            {
                TempData["Error"] = "Mesaj bulunamadı!";
                return RedirectToAction("MessageList");
            }

            // Mesajı okundu olarak işaretle
            if (!value.IsRead)
            {
                value.IsRead = true;
                _context.SaveChanges();
            }

            return View(value);
        }

        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            if (value != null)
            {
                _context.Messages.Remove(value);
                _context.SaveChanges();
                TempData["Success"] = "Mesaj başarıyla silindi!";
            }
            return RedirectToAction("MessageList");
        }

        public IActionResult ToggleRead(int id)
        {
            var value = _context.Messages.Find(id);
            if (value != null)
            {
                value.IsRead = !value.IsRead;
                _context.SaveChanges();
                TempData["Success"] = value.IsRead ? "Mesaj okundu olarak işaretlendi!" : "Mesaj okunmadı olarak işaretlendi!";
            }
            return RedirectToAction("MessageList");
        }
    }
}