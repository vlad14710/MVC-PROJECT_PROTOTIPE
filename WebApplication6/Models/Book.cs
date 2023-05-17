using System.ComponentModel.DataAnnotations.Schema;
using WebApplication6.Models;
namespace WebApplication6.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public int PhoneNamber { get; set; }

        public DateTime BookingTime { get; set; }  

        [ForeignKey("Haircut")]
        public int? HaircutIdforBook { get; set; }
        public Haircut? Haircut { get; set; }

        
        

        public string Note { get; set; }

        
    }
}
