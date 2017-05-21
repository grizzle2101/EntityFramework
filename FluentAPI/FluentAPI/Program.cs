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
             *  --- Fluent API Demo ---
             *  Setup:
             *  -Create Database Pluto_FluentAPI
             *  -add-migration IntialModel (Do not update database)
             *  
             *  //Overriding them darn conventions with Fluent:
             *  Step 1 - Add in out Fluent to the PlutoContext
             *  Step 2 - add-migration -force to override the existing migration with our changes.
             *  After Inspecting the changes we made, we can see the cascase delete feature is on.
             *  This means if we delete an Author, we also delete the courses associated with that Author.
             *  Next change is to remove this DANGEROUS feature.
             *  
             *  //Removing Cascase Delete Feature:
             *  Step 1 - Add the WillCascadeOnDelete(false) method to the context.
             *  Step 2 - Add-migration -Force again to override the previous InitialModel
             *  DO NOT UPDATE DATABASE
             *  Works fine! Next Item!
             *  
             *  //TagCourses to CourseTags - Defining the Many to Many Relationship
             *  
             */
        }
    }
}
