namespace VidzyCodeFirstExcercise
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class VidzyContext : DbContext
    {
        //Step 3 - Creating our DBSets
        public DbSet<Video> Videos { get; set; }
        public DbSet<Genre> Genre { get; set; }

        // Your context has been configured to use a 'VidzyContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'VidzyCodeFirstExcercise.VidzyContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'VidzyContext' 
        // connection string in the application configuration file.
        public VidzyContext()
            : base("name=VidzyContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}