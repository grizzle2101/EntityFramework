namespace VidzyCodeFirstExcercise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingGenreAndVideoTables : DbMigration
    {
        public override void Up()
        {
            //Purge Any Existing Data
            //Sql("DELETE FROM Videos;");
            //Sql("DELETE FROM Genres;");
            
            //Create Dummy Data
            Sql("INSERT INTO Videos (Name, ReleasedData) VALUES ('First Movie', '1990-12-20')");
            Sql("INSERT INTO Videos (Name) VALUES ('Second Movie')");

            Sql("INSERT INTO Genres (Id ,Name) VALUES (1, 'Sci-Fi')");
            Sql("INSERT INTO Genres (Id ,Name) VALUES (2, 'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
