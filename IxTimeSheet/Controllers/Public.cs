using Microsoft.AspNetCore.Mvc;

namespace IxTimeSheet.Controllers
{
    public class Public : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
