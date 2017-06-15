using Queries.Persistence;
using System;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task 1 - Create Generic IReporitory interface to interact with Collections.

            //Task 2 - Implment this IRepository in Repository & Provide actual methods for handling of collections.

            //Task 3 - Create specific ICourseRepository interface, inherit from ICourseRepository but add new Methods.

            //Task 4 - Implment ICourseRepository Methods in CourseRepository, GetTopSellingCourses etc.

            //Task 5 - IUnit of Work Interface.

            //Task 6 - UnitOfWork 

            //Task 7 - Brining it all Togther

            //In Console Application we use USING, but this won't be the same for WPF or MVC

                                        //UnitOfWork & Passing Our Specific Context
            using (var unitOfWork = new UnitOfWork(new PlutoContext()))
            {
                //Example 1 - Get Course with ID  1
                //Courses now Repositories
                var course = unitOfWork.Courses.Get(1);
                Console.WriteLine("GetCourse with Id=1:");
                Console.WriteLine("{0} - {1}", course.Name, course.Id);

                //Example 2 Get ALLCourse with their Authors
                var allCourses = unitOfWork.Courses.GetCoursesWithAuthors(1, 5);
                foreach (var c in allCourses)
                    Console.WriteLine("\n {0} - {1}", c.Name, c.Author.Name);

                //Example 3 - Cascade Delete
                var author = unitOfWork.Authors.GetAuthorWithCourses(1); //Get Author & His Courses
                unitOfWork.Courses.RemoveRange(author.Courses); //Remove Courses First
                unitOfWork.Authors.Remove(author); //Remove Author after
                unitOfWork.Complete(); //Save any and all Changes.
            }
        }
    }
}
  