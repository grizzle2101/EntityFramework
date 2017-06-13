
using System;
using System.Linq;
using System.Data.Entity;

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

            ///* --- Lecture 57 - N+1 Issue ---
            // *  Lazy Loading, if used inappropriately can lead to N + 1 Queries.
            // */
            //var context = new PlutoContext();

            //var courses = context.Courses.ToList(); //ToList Forces Immediate Execution.

            ////Retriving Related Author Object
            //foreach (var course in courses)
            //    Console.WriteLine("{0} by {1}", course.Name, course.Author.Name); 

            ///* Query 1 - Retrive All Courses
            // * Query 2+ - Every Additional Query to Retrive the Author & Name for said Course
            // * We have 4 Authors, so we made 4 additional queries. Not very efficent!
            // * 
            // * Summary:
            // * Always keep an eye on the queries being ran, there may be more than you need!
            // */


            ///* --- Lecture 58 - Eager Loading ---
            // *  Loading Related Objects All at Once! No more Additional Queries!
            // *  -Using the Include Keyword & ToList(), we can force an Immediate Join Execution.
            // *  
            // */

            //var context = new PlutoContext();

            //Solution 1 - Magic String
            //var courses = context.Courses.Include("Author").ToList(); //Join Courses & Authors
            //IF we rename this property, this magic string will not throw an error at compile time!

            //Solution 2 - Lambda Version
            //var courses = context.Courses.Include(c => c.Author).ToList();

            //Soltuon 3 - Eager Load Multiple Properties
            //Say we want to get Moderators of Tags realted to a Course.
            //Tags is a collection, so we need a .Select to access the moderator property
            //var MultipleCourses = context.Courses.Include(a => a.Tags.Select(t => t.Moderator)).ToList();

            //foreach (var course in courses)
            //    Console.WriteLine("{0} by {1}", course.Name, course.Author.Name);

            ///* Result: 
            // * Solution 2 - Query One - We have a single Query Joining Courses & Authors @ the context.Courses line.
            // * Solution 3 - Single Join to include our Couese, Tags & Moderator
            // * Summary:
            // * Too many includes means the SQL becomes very complex and costly!
            // * When to use Eager Loading & Lazy Loading depends on the scenario!
            // */


            ///* --- Lecture 59 - Expicit Loading ---
            // *  Similar to Eager loading, we tell Entity to load related objects at immediately
            // *  But rather than Joins there will be Multiple Seperate Queries.
            // */

            //var context = new PlutoContext();

            ////Solution 1 - Eager Loading - Get all Courses for Particular Author
            ////var author = context.Authors.Include(a => a.Courses).Single(a => a.Id == 1);

            ////Solution 2 - Explicit Loading - MSDN Way
            ////This Solution Requires much more knowledge of the Context API
            ////This only works for a Single Entry, if we had more than one option we're fooked!
            //var author = context.Authors.Single(a => a.Id == 1);
            //context.Entry(author).Collection(a => a.Courses).Load();

            ////Solution 3 - The Mosh way!
            //context.Courses.Where(c => c.AuthorId == author.Id).Load();

            ///*
            // * Both Solution 2 & 3 will work for Expicit Loading, but Solution 3 works will multiple properties!
            // * We will have multiple simple queries instead of massive & complex Joins!
            // * 
            // * Another Benefit is we can apply filters to the related objects.
            // * Like say we want to get an Author and ONLY his free courses.
            // * Using Eager Loading, we load all courses and if the application is performance oriented, this will not do!
            //*/

            ////Solution 4 - Filtered Free Courses
            ////MSDN Way - Query to get access to Query Object - More API knowledge again!
            //context.Entry(author).Collection(a => a.Courses).Query().Where(c => c.FullPrice == 0).Load();

            ////Mosh Way
            //context.Courses.Where(c => c.AuthorId == author.Id && c.FullPrice == 0).Load();
            ///*
            // * The most important Take home is .Load(). This is how we force EXPLICIT Loading.
            // */

            //foreach (var course in author.Courses)
            //    Console.WriteLine("{0}", course.Name);

            /* Last Section - To Get Authors with Free Courses
             */
            var context = new PlutoContext();
            var authorz = context.Authors.ToList();
            var authorIds = authorz.Select(a => a.Id); //Getting List of Author IDs

            //MSDN Approach does not work with this, dosen't work with multiple objects!
            //context.Entry(authorz);

            //Mosh way - Selecting Multiple ID's Trick
            //Similar to Using IN keyword with SQL
            //Select Courses      //Where Author in List of Author ID's  // IsFree
            context.Courses.Where(c => authorIds.Contains(c.AuthorId) && c.FullPrice == 0).Load();

        }
    }
}
