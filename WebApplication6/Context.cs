

    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using WebApplication6.Models ;

    namespace WebApplication6
    {
        public class Context : DbContext
        {
            public DbSet<Registration> Registrations { get; set; }


            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=OurDatabase;Trusted_Connection=True;");
            }
        }
    }
