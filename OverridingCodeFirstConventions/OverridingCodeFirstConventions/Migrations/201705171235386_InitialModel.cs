namespace OverridingCodeFirstConventions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Author_Id", "dbo.Authors");
            DropForeignKey("dbo.TagCourses", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.TagCourses", "Course_Id", "dbo.Courses");
            DropIndex("dbo.TagCourses", new[] { "Tag_Id" });
            DropIndex("dbo.TagCourses", new[] { "Course_Id" });
            DropIndex("dbo.Courses", new[] { "Author_Id" });
            DropTable("dbo.TagCourses");
            DropTable("dbo.__MigrationHistory");
            DropTable("dbo.Tags");
            DropTable("dbo.Courses");
            DropTable("dbo.Authors");
        }
    }
}
