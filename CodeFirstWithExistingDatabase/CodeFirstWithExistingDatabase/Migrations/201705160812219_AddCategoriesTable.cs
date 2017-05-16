namespace CodeFirstWithExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    /*
     *  ---Problem: Our Migration is Empty
     *  -This is because the class we created is not discoverable by Entity.
     *  To Make it discoscoverable, we have to add it to the DbContext.
     *  
     *  --Added Categories to DB Contect and -Force ran the new migration.
     */
    public partial class AddCategoriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        //Changes Identity to False(Overrided Convention)
                        Id = c.Int(nullable: false, identity: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);


            //The SQL Method: Populating Table with some Data
            Sql("INSERT INTO Categories VALUES (1, 'Web Development')");
            Sql("INSERT INTO Categories VALUES (2, 'Programming')");
            Sql("INSERT INTO Categories VALUES (3, 'Accounting')");
        }
        
        public override void Down()
        {
            DropTable("dbo.Categories");
        }
    }
}
