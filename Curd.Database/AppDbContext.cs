using Curd.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curd.Database
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        // public DbSet<Product> Product { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }

       
    }
}
