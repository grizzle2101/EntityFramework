using System.Data.Entity;

namespace FluentAPI
{
    class PlutoContext : DbContext
    {
        public PlutoContext()
            : base("name=PlutoContext")
        {

        }
        //DB Sets
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
    }
}
