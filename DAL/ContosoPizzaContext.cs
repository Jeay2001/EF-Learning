using EF_Learning.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Learning.DAL
{
    internal class ContosoPizzaContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; } = null!;
        public DbSet<Order> Order { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.; Initial Catalog=ContosoPizza;Integrated Security=true;TrustServerCertificate=True;");
        }
    }
}
