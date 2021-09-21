using ECommerceW8.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceW8.Data
{
    public class ECommerceW8DbContext: DbContext
    {
        public ECommerceW8DbContext(DbContextOptions<ECommerceW8DbContext> options) : base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
