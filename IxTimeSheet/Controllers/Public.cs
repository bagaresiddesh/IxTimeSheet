using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IxTimeSheet.Controllers
{
    public class Public : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
