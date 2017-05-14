using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst___Tutorial_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Courses through Stored Procedure:
            var context = new PlutoDBContext();
            var courses = context.GetCourses();

            foreach(var course in courses)
            {
                Console.WriteLine("Title: {0}" , course.Title);
            }

            Console.WriteLine("---------------------------");

            //Find Author that Begins with M
            var author = from a in context.Authors
                         where a.Name.StartsWith("M")
                         select a;

            //Finding a Specific Author
            var myAuthor = context.Authors
                .Where(a => a.Name == "Mosh Hamedani")
                .FirstOrDefault();

            foreach (var aut in author)
            {
                Console.WriteLine("Title: {0}", aut.Name);
            }

            Console.WriteLine(myAuthor.Name);

            //Working with Enums Tutorial:
            var course = new Course();
            course.Level = CourseLevel.Beginner; //Beginner = 1


            Console.ReadKey();
        }
    }
}
