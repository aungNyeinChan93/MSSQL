using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tuto_01.Models;

namespace Tuto_01.Database
{
    public class AppDbContext:DbContext
    {

        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions option) :base(option)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MyDatabase;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;");
            }
        }

        public DbSet<CustomerModel> Customers {  get; set; }

        //public DbSet<OrderMode>
    }
}
