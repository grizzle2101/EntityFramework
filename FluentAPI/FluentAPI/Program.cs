﻿using System;
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
             *  --- Fluent API Demo ---
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
        }
    }
}
