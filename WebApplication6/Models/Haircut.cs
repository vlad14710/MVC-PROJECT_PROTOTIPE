using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication6.Models
{
    public class Haircut
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Info { get; set; }

        public int Price { get; set; }  

        public string ImageUrl { get; set; }

        [NotMapped]
        public IFormFile HaircutImage   { get; set; }

        public List<Book> Book { get; set; }

        public List<Coment> Coment { get; set; }

        public string BackImageUrl { get; set; }

        [NotMapped]
        public IFormFile BackImage { get; set; }
    }
}
