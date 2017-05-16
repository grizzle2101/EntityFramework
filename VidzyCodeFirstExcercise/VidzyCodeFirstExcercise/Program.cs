using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidzyCodeFirstExcercise
{
    class Program
    {
        static void Main(string[] args)
        {
            // --- First Iteration: ---
            //Objective - Create Video & Genre Tables (Many to Many)
            //Step 1 - install-package EntityFramework
            //Step 2 - Create Class Objects
            //Step 3 - Create Context - Add ADO.Net Entity Data Model - Code First from Empty Database.
            //Step 4 -Add Domain Objects to Context
            //Step 5 - Create Database & Configure Connection String
            //Step 6 - Enable Migration & Create Initial Model Migration


            // --- Second Iteration ---
            //Objective: Change Videos only have ONE Genre
            //Step 1 - Remove the Collection of Genres from Video & Replace with single property.
            //Step 2 - Add Migration & Update-database

            // --- Third Iteration ---
            //Objective: Add Classifications to Video
            //Step 1 - Create the Enum : Byte
            //Step 2 - Add Property to Video Class
            //Step 3 - Add Migration & Update Database

            // --- Finishing Touches ---
            //The DBA Expects us to provide the Database Scripts
            //update-database -Script -SourceMigration:Migr1 -TargetMigration:Migr2

        }
    }
}
