namespace CodeFirstWithExistingDatabase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PlutoContext : DbContext
    {
        public PlutoContext()
            : base("name=PlutoContext") //Connection String Works as normal.
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; } //Plural Naming Issues with Entity, it happens : )
        public virtual DbSet<Tag> Tags { get; set; }
        
        //Introducing Categories to make it Discoverable, and create the Proper Migrations.
        //Deleting Categories from Model!
        //public virtual DbSet<Category> Categories { get; set; }

        //Whats this new model?
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(e => e.Courses)
                .WithOptional(e => e.Author)
                .HasForeignKey(e => e.Author_Id);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("TagCourses").MapLeftKey("Course_Id"));
        }
    }
}
