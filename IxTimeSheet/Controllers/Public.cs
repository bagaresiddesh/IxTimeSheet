using Microsoft.AspNetCore.Mvc;

namespace IxTimeSheet.Controllers
{
    public class Public : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            //Getting username(mail) where user is logged in 
            var username = User.Identity.Name;

            ViewBag.Username = username;

            return View();
        }
    }
}
