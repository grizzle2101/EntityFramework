using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnnotations
{
    class Program
    {
        static void Main(string[] args)
        {
            //Overring Code First Conventions

            /*
             * --- Lecture 1 - Overriding Conventions ---
             * By Convention, Strings are nullable, so by default our database strings are nullable.
             * 
             * Objective 1 - Override this convention using Data Annotation:
             * Step 1 - Edit the Description Property in the Course Class & add the [Required] data annotation.
             * Step 2 - Create a migration to reflect this change.
             * step 3 - Update-Database
             */


            /*
            * --- Lecture 3 - Data Annotations Demo ---
            * Step 1 - Create Blank Database Pluto_DataAnnotations & Configure Connection string to match.
            * Step 2 - Create the Domain Objects eg Course, Author, Tags etc.
            * Step 3 - Create the Context that Implments the DBSets for these Objects.
            * Step 4 - enable-migrations
            * Step 5 - Create InitialModel
            * 
            * Objective:
            * After running the InitialModel migration, we can see the default configuration.
            * Course Table:
            * ID = Primary Key, int & NOT NULLABLE
            * Name = Nvarchar(Max) & NULLABLE
            * Author_ID, we don't like this convention blehhh!
            * 
            * Applying some Annotations:
            * Step 1 - Applying [Required] & [MaxLength(x)] to Name & Description.
            * Step 2 - Create property with desired named for Foreign Key Authors.
            * Step 3 - Link this new Property to Author Navigation property.
            * Step 4 - add-migration AddAnnotationsToCourseTable (Database Centric names again)
            * Step 5 - Update-Database & see the new Database changes we made.
            */

            Console.ReadKey();
        }
    }
}
