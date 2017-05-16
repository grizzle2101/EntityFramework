using System.Collections.ObjectModel;

namespace CodeFirstWithExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    //Class created when you Enable Migrations.
    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstWithExistingDatabase.PlutoContext>
    {
        public Configuration()
        {
            /*
             * This feature will be thrown out in the next version of Entity, but basically we have 2 versions of migrations
             * Code First Migrations & Automatic Migrations.
             * With Code First we have to manually run the migrations & update the database, with the automatic feature Entity will compare
             * the database schema against what is specified in your code. If there is any mismatch, then it will be automatically upgraded.
             * This is super dangerous for Production, so its not a much used feature.
             */
            AutomaticMigrationsEnabled = false;
            //You can set the Migration properties and stuff here.
            //this.MigrationsAssembly = null;

        }

        //We can use this method to populate the database once tables are created.
        protected override void Seed(CodeFirstWithExistingDatabase.PlutoContext context)
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

            //This is used to create our Development Data, NOT PRODUCTION DATA.

            //Creating an Author and his Courses
            context.Authors.AddOrUpdate(a => a.Name,
                new Author
                {
                    Name = "Author 1",
                    Courses = new Collection<Course>()
                    {
                        new Course() {Name = "Course for Author 1", Description = "This was created through a seed method."}
                    } 
                }
                );
        }
    }
}
