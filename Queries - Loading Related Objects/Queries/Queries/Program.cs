
using System;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            ///* --- Lecture 56 - Lazy Loading
            // *  Deferring until ABSOLUTELY neccessary
            // *  -Use when loading an object graph is costly.
            // *  -During startup of an application, lazy load these objects so the application works well.
            // *  -Used in Desktop Application
            // *  -Avoid in Web Applications
            // *  -Methods to Disable Lazy Loading
            // *  -A: Remove Virtual Keyword from properties eg public virtual tags
            // *  -B: Remove through configuration this.Configuration.LazyloadingEnabled = false;
            // */

            //var context = new PlutoContext();

            //var course = context.Courses.Single(c => c.Id == 2); //Load a Single Course (Query 1)

            ////Then Perform another Query to Initalize the Tags for that Particular Course. (Query 2)
            ////Lazy Loading, Tags are deffered until the very last moment!
            //foreach (var tag in course.Tags)
            //    Console.WriteLine(tag.Name);

            /* --- Lecture 58 - N+1 Issue ---
             *  Lazy Loading, if used inappropriately can lead to N + 1 Queries.
             */
            var context = new PlutoContext();

            var courses = context.Courses.ToList(); //ToList Forces Immediate Execution.

            //Retriving Related Author Object
            foreach (var course in courses)
                Console.WriteLine("{0} by {1}", course.Name, course.Author.Name); 

            /* Query 1 - Retrive All Courses
             * Query 2+ - Every Additional Query to Retrive the Author & Name for said Course
             * We have 4 Authors, so we made 4 additional queries. Not very efficent!
             * 
             * Summary:
             * Always keep an eye on the queries being ran, there may be more than you need!
             */


            /* --- Lecture 59 - Eager Loading ---
             *  Loading Related Objects All at Once!
             */
        }
    }
}
