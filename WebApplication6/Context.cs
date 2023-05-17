

    using System;
    using System.Collections.Generic;
    using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
    using WebApplication6.Models ;

namespace WebApplication6
{
    public class Context : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Registration> Registrations { get; set; }

        public DbSet<Haircut> Haircut { get; set; }

        public DbSet<Book> Book { get; set; }

        public DbSet<Role> Role { get; set; }

        

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        

        
    }
}
