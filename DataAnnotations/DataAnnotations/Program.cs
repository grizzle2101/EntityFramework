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
            * Stopped @ 2.37
            */

            Console.ReadKey();
        }
    }
}
