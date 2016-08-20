using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestWeb.DAL.Entities;

namespace TestWeb.DAL
{
    public class TestWebContext : DbContext
    {
        public TestWebContext() : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=100;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(a => a.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Product>().HasKey(a => a.Id);
            base.OnModelCreating(modelBuilder);
        }
        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);
        }



    }
}