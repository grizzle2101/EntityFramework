using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace FluentAPI.Migrations.EntityConfigurations
{
    //Using EntityTypeConfiguration Class
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            //Task 1 - Remove modelBuilder.Entity<Course>()
            //Task 2 - Remove . before .Propert and start of each code block.
            //Task 3 - How to Organize these - Table Ovverrides

            //Change Names First (Alphabetically):
            ToTable("tbl_Course");
            //Primary Keys Next (Alphabetically):
            HasKey(c => c.Id);

            //Configure Properties - Alphabetically:
            //D
            Property(c => c.Description)
            .IsRequired()
            .HasMaxLength(2000);

            //N
            Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(255);

            //After Properties we work on Relationships - Alphabetically:
            //A
            HasRequired(c => c.Author) 
            .WithMany(a => a.Courses) 
            .HasForeignKey(c => c.AuthorId)
            .WillCascadeOnDelete(false);

            //C
            HasRequired(c => c.Cover)
            .WithRequiredPrincipal(c => c.Course);

            //T
            HasMany(c => c.Tags) 
            .WithMany(t => t.Courses) 
            .Map(m =>
            {
                m.ToTable("CourseTags");
                m.MapLeftKey("CourseID");
                m.MapRightKey("TagId");
            });

            
        }
    }
}
