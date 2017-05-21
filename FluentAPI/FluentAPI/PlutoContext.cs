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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Change 1 - Name is NOT Nullable & 255 Length.
            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            //Change 2 - Description is NOT Nullable & 255 Length
            modelBuilder.Entity<Course>()
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

            //Change 3 - Course & Author Relationship (One to Many).
            //Change 4 - Removing Cascasing Delete Feature.
            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Author) //Course has Required Author
                .WithMany(a => a.Courses) //Author has MANY Courses
                .HasForeignKey(c => c.AuthorId)//New AuthorId Property to replace Author_Id(Convention)
                .WillCascadeOnDelete(false); //Turning off Cascase Delete

            //Change 5 - TagCourses Fixup
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Tags)
                .WithMany(t => t.Courses)
                .Map(m => m.ToTable("CourseTags"));


            base.OnModelCreating(modelBuilder);
        }
    }
}
