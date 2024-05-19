

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

        public DbSet<Coment> Coment { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Coment>()
                        .HasOne(c => c.Haircut)
                        .WithMany()
                        .HasForeignKey(c => c.HaircutIdforBook)
                        .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>()
                       .HasOne(c => c.Haircut)
                       .WithMany()
                       .HasForeignKey(c => c.HaircutIdforBook)
                       .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }



    }
}
