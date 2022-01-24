using Microsoft.AspNetCore.Mvc;

namespace IxTimeSheet.Controllers
{
    public class Private : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
