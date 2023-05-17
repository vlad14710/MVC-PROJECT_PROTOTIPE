using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebApplication6.Models
{
    public class Registration 
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }    
        public string SecondName { get; set; }
        public string PhoneNamber { get; set; }
        public string Password { get; set; } 
        public string Email { get; set; }


        

        [ForeignKey("Role")]
        [DefaultValue(1)]
        public int? RoleId { get; set; }
        public Role? Role { get; set; }




    }
}
