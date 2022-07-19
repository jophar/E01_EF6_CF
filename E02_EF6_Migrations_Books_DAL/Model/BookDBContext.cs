using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace E02_EF6_Migrations_Books_DAL
{
    public class BookDBContext : DbContext
    {
        public BookDBContext() : base("BooksDB")
        { }
             
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<DeweyDecimalClassification> Ddc { get; set; }

    }
}