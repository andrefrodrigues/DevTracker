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
            var fun = new Models.Paradigm { name = "Functional" };
            var csharp = new Models.Language { name = "C#" };
            var oop = new Models.Paradigm { name = "Object Oriented" };
            var js = new Models.Language { name = "Javascript" };
            if (csharp.Paradigms.Count == 0)
            {
                csharp.Paradigms.Add(oop);
                csharp.Paradigms.Add(fun);
                oop.Languages.Add(csharp);
                fun.Languages.Add(csharp);
            }
            if (js.Paradigms.Count == 0)
            {
                js.Paradigms.Add(oop);
                js.Paradigms.Add(fun);
                oop.Languages.Add(js);
                fun.Languages.Add(js);
            }
            
            context.Paradigms.AddOrUpdate(oop, fun);
            context.Languages.AddOrUpdate(csharp,js);

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
