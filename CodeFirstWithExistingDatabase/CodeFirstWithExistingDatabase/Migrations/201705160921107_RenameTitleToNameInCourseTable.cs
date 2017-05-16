namespace CodeFirstWithExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTitleToNameInCourseTable : DbMigration
    {
        public override void Up()
        {
            // ***Be careful here, we don't want to drop this column and lose all our data!***
            //Making Names NOT Nullable.
            AddColumn("dbo.Courses", "Name", c => c.String(nullable: false)); //Create New Column

            //Solution 2 - Custom SQL Method:
            Sql("UPDATE Courses SET Name=Title"); //Take Title Data & Assigning to Name            
            DropColumn("dbo.Courses", "Title"); //Dropping old Column

            //Solution 1: Use the Rename Method
            //RenameColumn("dbo.Courses", "Title", "Name");
        }
        
        //Always make sure the Downgrade Method here makes sense too.
        public override void Down()
        {
            AddColumn("dbo.Courses", "Title", c => c.String(nullable: false)); //Data should still be nullable.
            Sql("UPDATE Courses SET Title=Name"); //Doing the Reverse Operation to Restore Title Data.
            DropColumn("dbo.Courses", "Name");
        }
    }
}
