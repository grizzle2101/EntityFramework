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

            foreach (var course in query)
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

           

            /* --- Tutorial 48 - LINQ Syntax ---
             * In Real-World web applications, these Domain Objects like Courses might get VERY large, and or Optimization reasons,
             * we might want to return smaller objects with specific properties.
             * 
             * Task 1 - Simple Query
             * Task 2 - Optimized Query
             * Task 3 - Grouping
             * Task 4 - Grouping with Aggregate Function
             * 
             */

            //Task 1 - Simple Query
            //Find All Courses for AuthorId = 1
            var simpleQuery =
                from c in context.Courses
                where c.AuthorId == 1
                select c;

            //Task 2 - Optimized Query
            //Find All Courses for AuthorId = 1, but return an Optimized Annoymous Object
            var optimizedQuery =
                from c in context.Courses
                where c.AuthorId == 1
                orderby c.Level descending, c.Name //Order by Multiple Properties
                select new { Name = c.Name, Author = c.Author }; //Steamlined Annoymous Object

            //Task 3 - Grouping 
            //Gropup by Course Level
            var groupedByLevel = 
                from c in context.Courses
                group c by c.Level 
                into g //Variable to Contain Grouped Data
                select g;

            
            //Display the Grouping
            foreach(var group in groupedByLevel)
            {
                Console.WriteLine(group.Key); //Group Key will be the Course.Level eg 1, 2, 3.

                foreach(var course in group)
                {
                    Console.WriteLine("\t{0}", course.Name);
                }
            }

            //Task 4 - Group with Aggregate Function
            foreach (var group in groupedByLevel)
            {
                Console.WriteLine("{0} {1}", group.Key, group.Count());
            }

            //Task 5 - Joins
            //Imagine we didn't have these Navigation Properties... This is where we use JOIN.
            var joinQuery =
                from c in context.Courses
                join a in context.Authors on c.AuthorId equals a.Id
                select new { CourseName = c.Name, AuthorName = a.Name };

            //Task 6 - Group Join
            //Count All Authors & Courses
            var groupJoin =
                from a in context.Authors
                join c in context.Courses on a.Id equals c.AuthorId
                into g //Group Join
                select new { AuthorName = a.Name, Courses = g.Count()};

            foreach(var x in groupJoin)
            {
                Console.WriteLine("{0} {1}", x.AuthorName, x.Courses);
            }

            //Task 7 - Cross Join
            //Every Author and Every Course
            var crossJoin =
                from a in context.Authors
                from c in context.Courses
                select new { AuthorName = a.Name, CourseName = c.Name };

            foreach(var x in crossJoin)
            {
                Console.WriteLine("{0}- {1}", x.AuthorName, x.CourseName);
            }

            Console.ReadKey();
        }
    }
}
