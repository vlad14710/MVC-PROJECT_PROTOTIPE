namespace WebApplication6.Models
{
    public class Role
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public List<Registration> Registration { get; set; }

    }
}
