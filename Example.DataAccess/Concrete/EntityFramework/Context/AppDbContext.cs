using Example.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.DataAccess.Concrete.EntityFramework.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        //public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MUSTAFA;Database=Example_DB;Trusted_Connection=True;Encrypt=False;MultipleActiveResultSets=true");
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
