using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAnimalPassport.Areas.Identity.SD;
using WebAnimalPassport.Models;

namespace WebAnimalPassport.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.IsInRole(Roles.Role_Owner))
            {
                return Redirect("/Animal/List");
            }
            else
            {
                return Redirect("/Identity/Account/Login");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}