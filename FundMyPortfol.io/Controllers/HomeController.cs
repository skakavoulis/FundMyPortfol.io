using FundMyPortfol.io.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FundMyPortfol.io.Controllers
{
    public class HomeController : Controller
    {
        #region Public Methods

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [ResponseCache(Duration = 0,Location = ResponseCacheLocation.None,NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
            ViewData["loginLabel"] = "Login";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        #endregion Public Methods
    }
}
