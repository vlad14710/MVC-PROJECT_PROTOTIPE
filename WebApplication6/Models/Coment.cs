using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication6.Models
{
    public class Coment
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        [ForeignKey("Haircut")]
        public int? HaircutIdforBook { get; set; }
        public Haircut? Haircut { get; set; }

        public string UserComent { get; set; }
    }
}
