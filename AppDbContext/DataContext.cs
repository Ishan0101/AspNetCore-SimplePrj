using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using MyShop.Views.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.AppDbContext
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) :
            base(options)
        {

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Model> Models { get; set; } 
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


    }
}
