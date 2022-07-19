namespace E02_EF6_Migrations_Books_DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<E02_EF6_Migrations_Books_DAL.BookDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(E02_EF6_Migrations_Books_DAL.BookDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Ddc.AddOrUpdate(p=>p.DeweyID,
                new DeweyDecimalClassification { DeweyID = 1, DdcCode = "000", DDC = "Computer science, information and general works" },
                new DeweyDecimalClassification { DeweyID = 2, DdcCode = "100", DDC = "Philosophy and psychology" },
                new DeweyDecimalClassification { DeweyID = 3, DdcCode = "200", DDC = "Religion" }
            );
        }
    }
}
