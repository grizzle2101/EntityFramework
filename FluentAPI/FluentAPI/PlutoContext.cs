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
            //---Task 1 ---
            //Change - Name is NOT Nullable & 255 Length.
            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            //Change - Description is NOT Nullable & 255 Length
            modelBuilder.Entity<Course>()
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

            //---Task 2 ---
            //Change - Course & Author Relationship (One to Many).
            //Change - Removing Cascasing Delete Feature.
            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Author) //Course has Required Author
                .WithMany(a => a.Courses) //Author has MANY Courses
                .HasForeignKey(c => c.AuthorId)//New AuthorId Property to replace Author_Id(Convention)
                .WillCascadeOnDelete(false); //Turning off Cascase Delete

            //---Task 3 ---
            //Change - TagCourses Fixup
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Tags) //Course has MANY tags
                .WithMany(t => t.Courses) //Tags have MANY Courses
                                          //---Tutorial 41 -  Fluent API(Advanced Configurations)
                .Map(m =>
                {
                    m.ToTable("CourseTags");
                    m.MapLeftKey("CourseID");
                    m.MapRightKey("TagId");
                });

            ////---Task 4 ---
            //Change - Creating Cover & Course Relationship - One to One.
            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Cover) //Course MUST have a Cover
                .WithRequiredPrincipal(c => c.Course); //Cover MUST have a Course, but Couse is Parent.

            base.OnModelCreating(modelBuilder);
        }
    }
}
