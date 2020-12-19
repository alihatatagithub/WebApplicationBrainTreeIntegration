using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationBrainTreeIntegration.Models;

namespace WebApplicationBrainTreeIntegration.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.Entity<Book>().HasData(new Book()
        //    {
        //        Id = 1,
        //        Name = "C#",
        //        AutherName = "ALI",
        //        Price = 1000
        //    });

        //    builder.Entity<Book>().HasData(new Book()
        //    {
        //        Id = 2,
        //        Name = "Flutter",
        //        AutherName = "Mohamed",
        //        Price = 2000
        //    });

        //    builder.Entity<Book>().HasData(new Book()
        //    {
        //        Id = 3,
        //        Name = "Python",
        //        AutherName = "Khaled",
        //        Price = 3000
        //    });
        //}
        public DbSet<Book> Books { get; set; }
    }
}
