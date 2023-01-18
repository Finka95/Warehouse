using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Worker>? Workers { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Department>? Departments { get; set; }

        public RepositoryContext(DbContextOptions options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
