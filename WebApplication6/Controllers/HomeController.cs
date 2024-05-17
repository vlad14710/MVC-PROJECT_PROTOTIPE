using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication6.Models;
using WebApplication6;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security;
using Microsoft.AspNetCore.Identity;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(UserManager<ApplicationUser> userManager,ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
            this.userManager = userManager;

        }
        

        public IActionResult Index()
        {
            
            var Query = _context.Registrations.ToList();
            return View(Query);
        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Registration userdata)
        {
            using (_context)
            {
                var user = _context.Registrations.Single(u => u.FirstName == userdata.FirstName && u.Password == userdata.Password);
                if (user != null)
                {
                    
                    
                    return RedirectToAction(nameof(Index));
                }

                return View();
            }

            
        }

        public async Task<IActionResult> CreateBook()
        {

            if (!string.IsNullOrEmpty(User.Identity.Name))
            {

                await Task();
                
            }
            ViewBag.Haircut = _context.Haircut.ToList();
            return View();
        }
        public async Task Task()
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                throw new InvalidOperationException("User is null.");
            }

            var lastName = user.LastName.ToString();
            ViewBag.lastName = lastName;
            
        }






        [HttpPost]
        
        public IActionResult CreateBook(Book book)
        {
            if (book.Note == null)
            {
                book.Note = "defult";
            }
            _context.Add(book);
            _context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("List", "Haircut");
        }

        public IActionResult ListBook()
        {


            ViewBag.Haircut = _context.Haircut.ToList();
            List<Book> Book = _context.Book.ToList();



            return View(Book);
            
        }


        public IActionResult FilterByDate(string selectedDate)
        {
            DateTime Date = DateTime.Parse(selectedDate);
            List<Book> Book = _context.Book.Where(d => d.BookingTime.Date == Date.Date).ToList();
            return View(Book);
        }


        public IActionResult CreateReg()
        {
           
            
            ViewBag.RoleId = new SelectList(_context.Role, "Id" , "Name" );
            
            return View();
        }

       



        public IActionResult ListHaircut ()
        {

            return View();
        }
        


        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Registration USER)
        {
            Registration registration = new Registration();
           
            if (ModelState.IsValid)
            {
                _context.Add(USER);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Createtest([Bind("Id,Title,ReleaseDate,Genre,Price")] Registration USER)
        {
            Registration registration = new Registration();
            
            if (ModelState.IsValid)
            {
                _context.Add(USER);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Detail()
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