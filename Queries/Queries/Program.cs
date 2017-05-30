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

            /*
             *  --- Lecture 49 - LINQ Extention Methods ---
             */

            //Task 1 - Restrictions -  Get All Level 1 Courses
            var myContext = new PlutoContext();

            var AllLevelOneCourses = myContext.Courses
                .Where(c => c.Level == 1);

            Console.WriteLine("\n ---All Level One Courses:---");
            foreach(var course in AllLevelOneCourses)
            {
                Console.WriteLine("{0}" , course.Name);
            }

            //Task 2 - Ordering - Order By Name
            var OrderedLevelOneCourses = context.Courses
                .Where(c => c.Level == 1)
                .OrderByDescending(c => c.Name)
                .ThenByDescending(c => c.Level); //Multiple Types of Ordering using ThenBy

            Console.WriteLine("\n ---Ordering by Level & Name:---");
            foreach (var course in OrderedLevelOneCourses)
            {
                Console.WriteLine("{0}, {1}", course.Name, course.Level);
            }

            //Task 3 - Projection
            /*Say we have HUGE Domain Models, and for performance we only want to use a small subset of that data, projection is
             * how we do that. The same as Annoymous methods we did for LINQ Syntax.
             * 
             * Note:
             * See we use the the c.Author navigation property to access the Author Name, instead of doing a join like in normal SQL.
             * 
             * Change 2:
             * Rather than using select, which returns a List, we can use SelectMany to Flatten the hieracy of lists so we just have the
             * property that we wish to access
            */
            var tags = context.Courses
                .Where(c => c.Level == 1)
                .OrderBy(c => c.Name)
                //.Select(c=> new { CourseName = c.Name, AuthorName = c.Author.Name}); //Retuning an Annoymous Method
                //.Select(c => c.Tags);
                .SelectMany(c => c.Tags);

            //foreach(var c in SmallSampleOfData)
            //{
            //    foreach (var tag in c)
            //        Console.WriteLine(tag.Name);
            //}


            //Change 2: - Using Tag Instead of a List.
            Console.WriteLine("\n--- Selecting Small SubSet(Tags Only) of Course Data: ---");
            foreach (var t in tags)
                Console.WriteLine(t.Name);

            //Task 4 - Set Operators
            /*
             * In our Last Task 3, we got back a list of Tags, including a few duplicate C# Tags.
             * To Fix this we can use the Distinct Keyword, to retrive the DISTINCT records.
             */
            var distinctTags = context.Courses
                .Where(c => c.Level == 1)
                .OrderByDescending(c => c.Name)
                .ThenByDescending(c => c.Level)
                .SelectMany(c => c.Tags)
                .Distinct();

            Console.WriteLine("\n--- Selecting Distinct Tags Only: ---");
            foreach (var t in distinctTags)
                Console.WriteLine(t.Name);

            //Task 5 - Grouping
            /*
             * In the previous LINQ Syntax tutorials we demonstrated how grouping is different then with normal SQL.
             * In LINQ we use GroupBy to break down a list into multiple groups eg courses into levels.
             */

            var GroupedList = context.Courses
                .Select(c => new { AuthorName = c.Author.Name, CourseName = c.Name, Level = c.Level})
                .GroupBy(c => c.Level);


            Console.WriteLine("\n--- Grouping By Level: ---");
            foreach (var group in GroupedList)
            {
                Console.WriteLine(group.Key);
                foreach(var item in group)
                {
                    Console.WriteLine("{0} - {1} - {2}" , item.CourseName, item.AuthorName, item.Level);
                }
            }

            //Task 6 - Joins
            /*
             * 3 Types of Join in LINQ Extenstion Methods
             * InnerJoin - No Relation in our objects, but we want to associate them.
             * GroupJoin
             * CrossJoin
             */

            var innerJoin = context.Courses.Join(context.Authors, //Join on Authors
                c => c.AuthorId, //Take AuthorId from Course Table
                a => a.Id, //Take ID from Artist Table
                (course, author) => new //Expected Output, a CourseName & AuthorName
                    {
                        CourseName = course.Name,
                        AuthorName = author.Name
                    });

            Console.WriteLine("\n --- InnerJoin Data from Courses & Authors ---");
            Console.WriteLine("(Imagine we didn't already have this navigation property)");
            foreach (var item in innerJoin)
                Console.WriteLine("{0} - {1}", item.AuthorName , item.CourseName);

            //Group Join
            /*
             * Group Join is useful for scenarios when we would use a Left Join in SQL and an Aggregate function.
             * Eg Author & Courses, give all Authors & Count of their courses
             */

            var GroupJoin = context.Authors
                .GroupJoin(context.Courses, a => a.Id, c => c.AuthorId, (author, course) => new
                {
                    Author = author,
                    Courses = course.Count()
                });

            Console.WriteLine("\n --- Group Join - Author Name & Count from Course Table ---");
            foreach (var item in GroupJoin)
                Console.WriteLine("{0} - Count:{1}" , item.Author.Name, item.Courses);


            //Cross Join
            /*
             * Cross Join returns a list of every possible combination of the data between 2 tables. With extenstion methods
             * we don't have a method called Cross Join, but we do have SelectMany()
             */

            var CrossJoin = context.Authors
                .SelectMany(a => context.Courses, 
                (author, course) => new
                {
                    AuthorName = author.Name,
                    CourseName = course.Name
                });

            Console.WriteLine("\n --- Cross Join - Return all Courses & Authors(Some Courses should be shared) ---");
            foreach (var item in crossJoin)
                Console.WriteLine("{0}, {1}" ,item.AuthorName, item.CourseName);

            Console.ReadKey();
        }
    }
}
