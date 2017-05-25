using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *  --- Tutorial 40 - Fluent API Demo ---
             *  Setup:
             *  -Create Database Pluto_FluentAPI
             *  -add-migration IntialModel (Do not update database)
             *  
             *  //Task 1 - Overriding them darn conventions with Fluent:
             *  Step 1 - Add in out Fluent to the PlutoContext
             *  Step 2 - add-migration -force to override the existing migration with our changes.
             *  After Inspecting the changes we made, we can see the cascase delete feature is on.
             *  This means if we delete an Author, we also delete the courses associated with that Author.
             *  Next change is to remove this DANGEROUS feature.
             *  
             *  //Task 2 - Removing Cascase Delete Feature:
             *  Step 1 - Add the WillCascadeOnDelete(false) method to the context.
             *  Step 2 - Add-migration -Force again to override the previous InitialModel
             *  DO NOT UPDATE DATABASE
             *  Works fine! Next Item!
             *  
             *  //Task 3 - TagCourses to CourseTags - Defining the Many to Many Relationship
             *  Step 1 - Add the Many to Many relationship into the context.
             *  Define that 2 way relationship.
             *      modelBuilder.Entity<Course> //Starting from Course
             *      .HasMany(c => c.Tags) //Course Has MANY tags
             *      .WithMany(t => t.Courses) //Tags Has MANY Courses
             *      .map(m => m.ToTable("CourseTags")); //Mapping Object ToTable Method & Provide Name.
             *  Step 2 - add-migration -force
             *  
             *  //Task 4 -Creating Cover & Defining Relationship
             *  Step 1 - Create Cover Class
             *  Step 2 - Add Cover Navigation Property into Course Class.
             *  Error Occurs! Unable to determine the Principal & Dependent
             *  Remember this is our previous lessons, we have to define which is parent.
             *  When adding records to database, the parent must be updated first before child table.
             *  
             *  Step 3 - Override Convention & Specify the Relationship
             */

            /*
             * ---Tutorial 41 - Tutorial 41 -  Fluent API(Advanced Configurations)---
             *  Problem:
             *  Our intmediary Table CourseTags has that DISGUSTING Tag_Id default Convention, and we need to figure out how to remove it.
             *  
             *  
             *  Step 1 - Edit the Pluto Context
             *  Step 2 - Create the Mappings and provide the property names for ToTable, MapLeftKey, MapRightKey.
             *  Stpe 3- add-migration InitialModel -Force
             *  Step 4 - Observer the new Naming Convention override in the Migrations from Tag_Id to TagId.
                });
             */

            /*
            * ---Tutorial 42 - Organizing Fluent API Configurations ---
            *  
            *  The Model we have been working on in relativly small, but in an Enterprise Application, there could be HUGE amounts
            *  of Tables, Models, Migrations etc which all needs to be Organized.
            *  
            *  Objective:
            *  Rewrite OnModel Creation to be more maintainable.
            *  
            *  Step 1 - Create a Folder called "EntityConfigurations"
            *  Step 2 - Create a Class called "CourseConfiguration"
            *  Step 3 - Take the Configuration Code from PlutoContext and move it into the CourseConfiguration Class.
            *  Step 4 - Remove modelBuilder.Entity<Course>() because we don't need it anymore, thats for the Context to resolve.
            *           Remove the Full Stops before Property and the start of each code block.
            * Step 5 - Organize the Configuration using Moshs Standard
            *       Table Names, Primary Keys, Properties & Relationships. (All organised Alphabetically)
            *       
            * Step 6 - In the Context, use modelBuilder.Configurations.Add(new CourseConfiguration()); to pass our configuration to the Model
            *       Builder, and bam we got ourselves out configured DB in one line. Very Clean.
            *       Note:
            *       As the Database gets bigger, sorting these Alphabetically, and within their own sections will make life ALOT easier.
            */
        }
    }
}
