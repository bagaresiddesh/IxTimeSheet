using Microsoft.AspNetCore.Mvc;

namespace IxTimeSheet.Controllers
{
    public class Public : Controller
    {
        public IActionResult Index()
        {
            string username= User.Identity.Name;

            return RedirectToAction("Index", "TimeLogs", new { arg = username });
        }
    }
}
