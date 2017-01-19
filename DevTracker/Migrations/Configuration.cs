namespace DevTracker.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DevTracker.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DevTracker.Models.ApplicationDbContext context)
        {
            var csharp = new Models.Language { name = "C#" };
            var oop = new Models.Paradigm { name = "Object Oriented" };
            context.Languages.AddOrUpdate(csharp,new Models.Language {name="Javascript" });
            context.Paradigms.AddOrUpdate(oop, new Models.Paradigm {name="Functional" });
            context.Lang_Paradigms.AddOrUpdate(new Models.Lang_Paradigm { LANG = csharp, PARAD = oop });
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
        }
    }
}
