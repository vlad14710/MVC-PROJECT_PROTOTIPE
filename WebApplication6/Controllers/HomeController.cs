using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication6.Models;
using WebApplication6;
namespace WebApplication6.Controllers
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
            using var dbCon = new Context();
            var Query = dbCon.Registrations.ToList();
            return View(Query);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create (string firstname ,string secondname,string phonenumber,DateTime book)
        {
            Registration registration = new Registration() { FirstName = firstname, SecondName = secondname, PhoneNamber = phonenumber };
            using var dbCon = new Context();
            dbCon.Registrations.Add(registration);
            dbCon.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}