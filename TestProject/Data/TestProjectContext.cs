using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestProject.models;
using TestProject.Models;

namespace TestProject.Data
{
    public class TestProjectContext : DbContext
    {
        public TestProjectContext (DbContextOptions<TestProjectContext> options)
            : base(options)
        {
        }

        public DbSet<TestProject.models.users> users { get; set; } = default!;

        public DbSet<TestProject.Models.Address>? Address { get; set; }

        public DbSet<TestProject.Models.Category>? Category { get; set; }

        public DbSet<TestProject.Models.Product>? Product { get; set; }

        public DbSet<TestProject.Models.Banner>? Banner { get; set; }

        public DbSet<TestProject.Models.Offer>? Offer { get; set; }

        public DbSet<TestProject.Models.Cart>? Cart { get; set; }

        public DbSet<TestProject.Models.CartItem>? CartItem { get; set; }

        public DbSet<TestProject.Models.Wishlist>? Wishlist { get; set; }

        public DbSet<TestProject.Models.Order>? Order { get; set; }
    }
}
