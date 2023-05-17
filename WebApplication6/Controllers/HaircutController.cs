using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication6.Models;
using WebApplication6;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication6.Controllers
{
    public class HaircutController : Controller
    {
        
        private readonly IWebHostEnvironment WEBHOST;
        private readonly Context _context;

        public HaircutController(IWebHostEnvironment wEBHOST, Context context)
        {
            WEBHOST = wEBHOST;
            _context = context;

        }   

        public IActionResult Index()
        {
          
            List<Haircut> haircut = _context.Haircut.ToList();

           

            return View(haircut);
        }

       

        public IActionResult Delete(int id)
        {
           
            Haircut haircut = _context.Haircut.SingleOrDefault(d => d.Id == id);

            return View(haircut);

            
        }

        [HttpPost]
        public ActionResult Delete(int id, Haircut data)
        {
            
            var haircut = _context.Haircut.SingleOrDefault(d => d.Id == id);
            string Folder = Path.Combine(WEBHOST.WebRootPath, "images");
            if (haircut != null)
            {
                System.IO.File.Delete(Path.Combine(Folder, haircut.ImageUrl));
                System.IO.File.Delete(Path.Combine(Folder, haircut.BackImageUrl));
                _context.Haircut.Remove(haircut);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }



        public ActionResult Edit(int id)
        {
            
            Haircut haircut = _context.Haircut.SingleOrDefault(d => d.Id == id);

            return View(haircut);
        }
       
        
        [HttpPost]
        public ActionResult Edit(int id, Haircut data)
        {
           
            Haircut haircut = _context.Haircut.SingleOrDefault(d => d.Id == id);
            string Folder = Path.Combine(WEBHOST.WebRootPath, "images");


            if (data.HaircutImage != null)
            {
               
                System.IO.File.Delete(Path.Combine(Folder, haircut.ImageUrl));

                string uniqueFileName = UploadedFile(data);
                haircut.ImageUrl = uniqueFileName;
            }

            if (data.BackImage != null)
            {
                System.IO.File.Delete(Path.Combine(Folder, haircut.BackImageUrl));

                string backFileName = GetBackImageFile(data);
                haircut.BackImageUrl = backFileName;
            }

            haircut.Name = Request.Form["Name"];

            haircut.Info = Request.Form["Info"];
            haircut.Price = int.Parse(Request.Form["Price"]);


            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            Haircut haircut = new Haircut();
            return View(haircut);
        }

        [HttpPost]
        public IActionResult Create(Haircut data)
        {
            
            
            string uniqueFileName = UploadedFile(data);
            string backFileName = GetBackImageFile(data);
            data.ImageUrl = uniqueFileName;
            data.BackImageUrl = backFileName;
            _context.Attach(data);
            _context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int id)
        {
            Haircut haircut = _context.Haircut.SingleOrDefault(d => d.Id == id);
            return View(haircut);
        }

        public IActionResult list()
        {
            List<Haircut> haircut = _context.Haircut.ToList();



            return View(haircut);
        }

        private string UploadedFile(Haircut model1)
        {
            string uniqueFileName = null;

            if (model1.HaircutImage != null)
            {
                string uploadsFolder = Path.Combine(WEBHOST.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model1.HaircutImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model1.HaircutImage.CopyTo(fileStream);
                }
                
            }
            
            return uniqueFileName;
        }


        private string GetBackImageFile(Haircut model1)
        {
            string uniqueFileName = null;

            if (model1.BackImage != null)
            {
                string uploadsFolder = Path.Combine(WEBHOST.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model1.BackImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model1.BackImage.CopyTo(fileStream);
                }

            }

            return uniqueFileName;
        }

    }
}
