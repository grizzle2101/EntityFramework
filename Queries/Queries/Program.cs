using System;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             *  --- Tutorial 47 - LINQ in Action ---
             *  This Solution has been created with the neccessary Seed Data for us to Query in this Tutorial.
             *  
             *  Using LINQ:
             *  Step 1 - Update-Database to build & Seed our Database.
             *  Step 2 - Create Instance of DBContext
             *  Step 3 - Instansiate the Context and write some queries.
             *  
             *  Extension Methods:
             *  Step 1 - Instansiate the Context and write some queries.
             *  
             *  Which is better?
             *  Personal Preference, if you prefer more SQL like ones, use LINQ, if you're okay with Lambdas, delegates
             *  actions etc use Extension Methods. In Reality the LINQ methods are a subset of the extension methods,
             *  so provide more functionality.
             */
            var context = new PlutoContext();

            //Linq Syntax
            var query =
                from c in context.Courses
                where c.Name.Contains("C#")
                orderby c.Name
                select c;

            foreach(var course in query)
            {
                Console.WriteLine(course.Name);
            }

            //Extension Methods
            var courses = context.Courses
                .Where(c => c.Name.Contains("C#"))
                .OrderBy(c => c.Name);

            foreach (var course in courses)
            {
                Console.WriteLine(course.Name);
            }

            Console.ReadKey();
        }
    }
}
