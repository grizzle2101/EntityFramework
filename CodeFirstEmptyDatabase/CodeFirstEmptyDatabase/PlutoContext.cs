using System.Data.Entity;

namespace CodeFirstEmptyDatabase
{
    public class PlutoContext : DbContext
    {
        //Create DBSets, the Collections of abstracted Database Entities.
        public DbSet<Course> Courses { get; set;}
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public PlutoContext()
            : base("name=DefaultConnection") //Point to connection in App.Config
        {

        }
    }
}
