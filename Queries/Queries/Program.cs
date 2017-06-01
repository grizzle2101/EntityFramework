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

            // --- Lecture 50 - Other Methods NOT supported by LINQ ---
            //Task 1- Partitioning
            /*
             * Imaging we want to display Courses & Pages, but we only have 10 courses per page. The way we would do that is
             * with Partitioning.
             */
             //Skip 10 Courses, Take the next 10.
            var secondPage = context.Courses.Skip(10).Take(10);

            /*
             *  Task 2 - Element Operators
             *  Everything we have done so far returns a list of elements, what if we want just a single one?
             */

            // --- First ---
            //Get First Default is Primary key, else provide Lambda
            //var firstItem = context.Courses.OrderBy(c => c.Level).First();

            //Safer Method, if there is no first return default.
            var firstItem = context.Courses.OrderBy(c => c.Level).FirstOrDefault(c => c.FullPrice > 100);
            Console.WriteLine("\nFirstOfDefault() - The First Item is {0}", firstItem.Name);

            /* --- Last ---
             * Last is a tricky one, as it will not work with SQL, for SQL we would need to order the list in descending then take last.
            */
            //var lastItem = context.Courses.LastOrDefault(); --Won't work with SQL
            var lastItem = context.Courses.OrderByDescending(c => c.Name).FirstOrDefault();
            Console.WriteLine("\nLast() - The Last Course is {0}" , lastItem.Name);

            /* --- Single ---
             * Get a single item back. Be careful with the criteria, if we have multiple records with the same Id, its gonna fall over!
            */
            var singleItem = context.Courses.SingleOrDefault(c => c.Id == 1);
            Console.WriteLine("\nSingleOrDefault() - The SINGLE item matching ID=1 - {0}", singleItem.Name);

            /* --- All ---
             * Do ALL Courses have a given criteria, eg are all course above 10? All returns boolean with our result.
           */
            var allItems = context.Courses.All(c => c.FullPrice > 10);
            Console.Write("\nAll() - There are Courses Over $10? {0}", allItems);

            /* --- ANY ---
             * Do we have ANY with a given criteria. eg Any Level 1 courses? Return results as boolean
            */
            var anyItem = context.Courses.Any(c => c.Name.Contains("C#"));
            Console.WriteLine("\nAny() - Any C# Books? {0}" , anyItem);

            /* --- Task 3 - Aggregating ---
             * Say we want to just simply Aggregate some data, eg Count all Courses
            */

            var courseCount = context.Courses.Count();
            Console.Write("\nCount() - We Have {0} Courses", courseCount);

            //Average, Max & Min
            var averageCoursePrice = context.Courses.Average(c => c.FullPrice);
            Console.WriteLine("\nAverage - The Average Price of a Course is ${0}" , averageCoursePrice);

            var cheapCourse = context.Courses.Min(c => c.FullPrice);
            Console.WriteLine("\nMin() - Cheapest Course we have ${0}", cheapCourse);

            var expensiveCourse = context.Courses.Max(c => c.FullPrice);
            Console.WriteLine("\nMax() - Most Expensive course we have ${0}" , expensiveCourse);

            //Chaining Aggregates
            var chainedAggregate = context.Courses.Where(c => c.Level == 1).Count();
            Console.WriteLine("\nTotal Number of Level 1 Courses = {0}", chainedAggregate);


            //Lecture 51 -  Defered Execution

            var Context = new PlutoContext();

            var Courses = context.Courses;

            //Delayed Execution Benefits, we take these queries and keep working on it!
            //Not a good idea to write queries like this, just showing you that they are not SQL at this stage.
            var filteredList = Courses.Where(c => c.Level == 1);
            var sortedList = filteredList.OrderBy(c => c.Name);

            Console.WriteLine("\n---Deferred Execution---");
            foreach (var c in Courses)
                Console.WriteLine(c.Name);

            //Task 2 - Immediately Execute Query
            /*
             * Step 1 - Create new Property in Course Class.
             * Step 2 - Attempt to Use our new Property
             * 
             * Error - Specific Member is not supported by LINQ to Entities.
             * 
             * Workaround:
             * Retrive the list here BEFORE we do the IsBeginnerCourse Check
             * There is a Caveat to this immediate execution, the performance impact!
             * 
             * Step 1 - use ToList().Where() to return the list BEFORE doing the IsBeginner Comparison
             * 
             * Note:
             * This is only ever suitable when performance is not a problem. On a very small application, with a very small data set.
             * Readability v Performance
             */

            //var beginnerCourse = context.Courses.Where(c => c.IsBeginnerCourse == true); //Runtime Exception Generated!

            //Workaround, Immediately loading using ToList()
            var beginnerCourse = context.Courses.ToList().Where(c => c.IsBeginnerCourse == true);

            Console.WriteLine("\n---Immediate Execution:---");
            foreach (var c in beginnerCourse)
                Console.WriteLine(c.Name);

            //Closing Note: Queries are NOT executed when instansiated. But When variable is queried, calling ToList, ToArray, ToDictionary
            //First, Last, Single, Count, Max, Min & Average.

            Console.ReadKey();
        }
    }
}
