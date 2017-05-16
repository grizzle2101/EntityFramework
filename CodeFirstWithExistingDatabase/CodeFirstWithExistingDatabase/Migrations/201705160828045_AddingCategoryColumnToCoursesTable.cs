namespace CodeFirstWithExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCategoryColumnToCoursesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Category_Id", c => c.Int());//Create Column in Coureses with our Convention catetory ID
            CreateIndex("dbo.Courses", "Category_Id"); //Index for finding Courses by a given Category.
            AddForeignKey("dbo.Courses", "Category_Id", "dbo.Categories", "Id"); // Reference to Foriegn key from Category table.

            //Adding some data with SQL again:
            Sql("UPDATE COURSES SET Category_Id=1"); //Setting all Course Categories to Web Devleopment
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "Category_Id" });
            DropColumn("dbo.Courses", "Category_Id");
        }
    }
}
