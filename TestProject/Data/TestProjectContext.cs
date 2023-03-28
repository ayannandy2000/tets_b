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
    }
}
