using System.Collections.ObjectModel;

namespace VidzyCodeFirstExcercise.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VidzyCodeFirstExcercise.VidzyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VidzyCodeFirstExcercise.VidzyContext context)
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

            //Adding our Sample Data
            //context.Videos.AddOrUpdate(
            //    v => v.Name,
            //    new Video()
            //    {
            //        Name = "Starship Troopers",
            //        Genres = new Collection<Genre>()
            //        {
            //            new Genre(){Id = 1, Name = "Sci-Fi"},
            //            new Genre(){Id = 2, Name = "Comedy"}
            //        }
            //    }
            //    );
        }
    }
}
