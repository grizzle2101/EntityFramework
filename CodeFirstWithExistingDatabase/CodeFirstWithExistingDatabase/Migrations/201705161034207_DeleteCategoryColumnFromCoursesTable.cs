namespace CodeFirstWithExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCategoryColumnFromCoursesTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Category_Id", "dbo.Categories"); //Drop Foreign Key because the relationship
            DropIndex("dbo.Courses", new[] { "Category_Id" }); //Delete Index
            DropColumn("dbo.Courses", "Category_Id"); //Delete Column Itself
            //Deleting a Navigation Property always shows the same 3 steps.
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Category_Id", c => c.Int());
            CreateIndex("dbo.Courses", "Category_Id");
            AddForeignKey("dbo.Courses", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
