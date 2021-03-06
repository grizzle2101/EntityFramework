﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstWithExistingDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

            //*****Lecture 1 - Code First with Existing Database *****//
            //Step 1 - Create Database, Run Script!
            //Step 2 - Add ADO.Net Entity Data Model - Select Code First from Existing Database
            //Step 3 - Entity had trouble finding the singular of Courses, so corrected the Class Course
            //Step 4 - Explore the Files Generated by Entity
            /*
             * In the Tags Class
             * public virtual ICollection{get; set;}
             **** In Tags Entity used a ICollection rather than the IList we used in the previous Lecture.
             *      The Virtual Keyword is used to lazy loading, which will be done in the next chapter.
             *      
             **** They Also use a different Constructor for Tag, that takes in a Courses Hashset, which can be used for retrival.
             *      We didn't think about this in the previous lecture, but this is the appropriate data strcuture for handling
             *      these composite key/many to many relationship value mentioned 
             */

            //*****Lecture 2 - Enabling Migrations *****//
            /*
             * Carrying on from our last lecture, we can see we don't have any migrations.
             * Step 1 - Enable Migrations "enable-migrations"
             * Step 2 - Create InitialModel Migration to Create our first Database
             *We can see in the InitalModel Migration, that is will create the tables Authors & Courses etc, which we arlready have
             * Step 3 - Use the Ignore Changes Switch, to tell Entity we have in the model already exists in the database.
             *        Command >  add-migration InitialModel -IgnoreChanges -Force
             * Step 4 - See Updated Model with no Create statements for Courses & Authors etc, looks good!
             * Step 5 - See Migration History Table created by Entity and bam, we're back in business.
             * 
             * Note:
             * We Can only run a single Migration script at a time, so we need to run this blank one in now.
             * Small Migrations = less risk, like commiting code, better to commit small bundles rather than 10,000 lines of code.
             */


            //*****Lecture 3 - Adding a new Class *****//
            /*
             *  ---Objective 1:
             * Creating and integrating a new class called Category eg Web Development, Programming, Accounting etc.
             * 
             * Step 1 - Create the Category Class with 2 properties
             * Step 2 - Create and Run this Migration
             *          Note: Naming Your Migrations:
             *          -Model Centric Naming Convention - AddCategory
             *          -Database Centric Convention - AddCategoriesTable
             *          
             *          Database centric is a good approach, because often times you can be making changes that don't have anything to see
             *          in your Model, like updating a stored procedure, or a trigger, or indexing a database etc.
             * Step 3 - Add Category to DBContext to make it discoverable by Entity.
             * Step 4 - Rerun the Migration to fix our blunder! We need to force an override > add-migration AddCategoriesTable -Force
             * Step 5 - Change the Migration a bit to suit our needs, use the Sql method to insert some data.
             * Step 6 - Update Database
             * 
             *  ---Objective 2:
             * Step 7 - Add this Category Type to the Courses Model.
             * Step 8 - Run the Migration
             * Step 9 - Edit the migration to suit our needs.
             * Step 10 - Insert Some Data into Courses & Authors (We already have data in Categories)
             */



            //*****Lecture 4 - Modifying an Existing Class *****//
            /*
             *  ---3 Modification Scenarios:
             *  Adding a new Property
             *  Modifying an Existing Property
             *  Deleting an Existing Property
             *  
             *  Scenario 1 - Adding a new Property:
             *  Step 1 - Adding New Property into Courses - DatePublished
             *  step 2 - Add Migration AddDatePublishedColumnToCoursesTable
             *  
             *  Scenario 2 - Changing Existing Column:
             *  Step 1 - Change Name in Courses to Name
             *  Step 2 - Add Migration RenameTitleToNameInCourseTable
             *  Step 3 - This Migration is DANGEROUS, will lose data by dropping the column in such a way. 
             *              We need to fix this before updating.
             *  Step 4 - Also have to do the same operation to the downgrade method.
             *  Step 5 - Update database
             *  
             *  
             *  Scenario 3 - Deleting a Column:
             *  Step 1 - Delete the DatePublished property from Course
             *  Step 2 - Add Migration DeleteDatePublishedColumnFromCoursesTable
             *  Step 3 - Update Database
             */



            //*****Lecture 5 - Deleting an Existing Class *****//
            /*
             *  Deleting Category Class
             *  From Initial Category Class & the Property from the Course Class.
             *  Remember, always use small meaningful changes.
             *  
             *  Step 1 - Remove the Category property from Course
             *  Step 2 - Add Migration & Update-database
             *  
             *  Step 3 - Delete the Category Class
             *  Step 4 - Delete the Category DBSet from PlutoContext
             *  Step 5 - 
             */


            //***** Lecture 6 - Recovering from Mistakes *****//
            /*
             * Earlier we deleted the DatePublished Column from the Courses Tables.
             * What if we want to get that back?
             * Code First is like Version Control, we can't delete the entry, that have to commit another to fix it.
             * 
             * Step 1 - Change the Model * Create another migration.
             * Step 2 - add-migration & update database
             */


            //***** Lecture 7 - Downgrading a Database *****//
            /*
             *  Downgrading our database could be an essential task fixing a Bug in earlier versions
             *  To Get an earlier version of the database, we have 2 options.
             *  
             *  --- Option 1: ---
             *  Checkout the specific version from version control
             *  Change the DB Name in Connection string
             *  Update-database (will run all the scripts retrived from GIT)
             *  
             *  --- Option 2: ---
             *  Say we want to keep the production data we have on file, but also rollback the database.
             *  -Run Update-Database
             *  -but provide a specific migration eg Migration F
             *  -Entity will run the Down method for migration G & H to bring is back to F.
             *  
             *  Step 1 - Check the Migration History Table in SQL to see the migrations that have been ran in.
             *  Step 2 - Identify the migration you would like to roll back to.
             *  Step 3 - run update-database -TargetMigration DeleteDatePublishedColumnFromCoursesTable
             *  Result - See the Migration History Table has been rolled back, and the changes in the databsae have been reverted.
             *  
             *  Before You Go - Run Update-Database to restore us back the latest version!
             */

            //***** Lecture 8 - Seeding Database *****//
            /*
             * Once we use the Enable Migration command, this configuration.cs file is created.
             * This Contains a Method called Seed, which is used to populate data once the database changed have been made.
             * 
             * Step 1 - See the Sample AddOrInsert in the Seed Method
             * Step 2 - ReWrite this Method to use real tables that we have created.
             * Step 3 - Run the Update-Database Command, check the databse for our new values, NOICE!
             */

            Console.ReadKey();
        }
    }


}
