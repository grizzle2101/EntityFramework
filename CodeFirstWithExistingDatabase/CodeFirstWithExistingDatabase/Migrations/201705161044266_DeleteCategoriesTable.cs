namespace CodeFirstWithExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteCategoriesTable : DbMigration
    {
        public override void Up()
        {
            //Create Storage Table
            CreateTable(
                    "dbo._Categories",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            //Migrate Data before dropping
            Sql("INSERT INTO _Categories (Name) SELECT Name FROM Categories");

            //Default Drop Method
            DropTable("dbo.Categories");
        }
        
        public override void Down()
        {
            //Doing the Opposite Operation here.
            //Recreate Categories Table
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            //Migrating Data from Temp Storage
            Sql("INSERT INTO Categories (Name) SELECT Name FROM _Categories");

            //Drop Storage Table
            DropTable("dbo._Categories");
        }
    }
}
