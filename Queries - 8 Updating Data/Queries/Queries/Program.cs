
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Lecture 64 - Adding Objects
             */

            //Task 1 - Adding a Course
            //var context = new PlutoContext();

            //var course = new Course
            //{
            //    Name = "New Course",
            //    Description = "New Description",
            //    FullPrice = 19.95f,
            //    Level = 1,
            //    Author = new Author { Id = 1, Name = "Mosh Hamedani" }
            //};
            //context.Courses.Add(course); //Add to Course DBSet in DB Context
            //context.SaveChanges(); //Create SQL

            /* Result - Our Record was added, but a Duplicate entry was made for Author Mosh Hamedani.
             * Problem - Because we used the NEW keyword for Author, the change tracker created this as a NEW entry.
             *           It was no idea that we already have an Author ID = 1 Mosh.
             *           
             * Solution 1 - Load the Author Object ID = 1 from the Context. (Works better in WPF/Desktop Applications)
             * Solution 2 - Use the AuthorID Foreign key (Works better in Web Applications)
             */

            //Solution 1 - Loading Objects from Memory.
            //In WPF Applications our Context is long lived, meaning they exist as long as the application is open.
            //It could be there because we retrived a list of Authors for a dropdown or whatever reason.
            //We can simply get it from the context without much penalty.
            // Caveeat - If the Author with ID 1 does not exist in the context, it will query database to retrive it.
            // Must be 100% sure you have this object in Memory already

            //var context = new PlutoContext();
            //var authors = context.Authors.ToList(); //List for Dropdown Example.
            //var author = context.Authors.Single(a => a.Id == 1);

            //var MaCourse = new Course
            //{
            //    Name = "New Course 2",
            //    Description = "New Description 2",
            //    FullPrice = 19.95f,
            //    Level = 1,
            //    Author = author
            //};
            //context.Courses.Add(MaCourse); //Add to Course DBSet in DB Context
            //context.SaveChanges(); //Create SQL

            //Solution 2 - Using the AuhorID Foreign Key property.
            //This Solution works better in Web Applications, as our Context Items are SHORT LIVED.
            //var context = new PlutoContext();

            //var MaCourse = new Course
            //{
            //    Name = "New Course 2",
            //    Description = "New Description 2",
            //    FullPrice = 19.95f,
            //    Level = 1,
            //    AuthorId = 1
            //};

            ////Solution 3 - Not so common Way
            ////We have an Author Object, but its not in our context. With all Moshs experience,
            //// never needed to use this Attach() method, solution 1 or 2 always worked.
            //// Your very tihgly coupling with Entity And if they change the Framework again, alott of refactoring will have to be done!

            ////Create Author Object
            //var author = new Author() { Id = 1, Name = "Mosh Test" };

            //var context = new PlutoContext();

            ////Attach Author Object to DBContext
            //context.Authors.Attach(author);

            //var MaCourse = new Course
            //{
            //    Name = "New Course 3",
            //    Description = "New Description 3",
            //    FullPrice = 19.95f,
            //    Level = 1,
            //    Author = author
            //};

            //context.Courses.Add(MaCourse);
            //context.SaveChanges();

            /*
             *  --- Lecture 65 - Updating Objects ---
             */

            var context = new PlutoContext();
            
            /* Find()
             * Same as Single(c => c.Id == 4)
             * Just provide the primary key 4, and even works with composite keys so TagCourses.Find(4, 4)
             */
             //Step 1 - Need to Load Course into Memory
            var course = context.Courses.Find(4); //Status = Unchanged

            //Changing some Property
            course.Name = "New Name"; //Status = Changed
            course.AuthorId = 2;

            context.SaveChanges();
        }
    }
}
