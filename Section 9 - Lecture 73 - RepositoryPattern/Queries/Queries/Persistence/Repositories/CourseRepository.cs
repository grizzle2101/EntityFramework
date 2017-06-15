using Queries.Core.Domain;
using Queries.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Queries.Persistence.Repositories
{
    //Task 4 - Implment Course Specific Methods in CourseRepository
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(PlutoContext context) //Taking in Pluto Context as base.Context
            : base(context)
        {
        }
        //Notice we use IEnumerable - Because Query execution will happen here within the CourseRepository class.
        public IEnumerable<Course> GetTopSellingCourses(int count)
        {
            return PlutoContext.Courses.OrderByDescending(c => c.FullPrice).Take(count).ToList();
        }

        public IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize = 10) //Default page Size = 10
        {
            //Remember we did this logic in the previous turorials, just need to centralize it here & return the result.
            return PlutoContext.Courses
                .Include(c => c.Author)
                .OrderBy(c => c.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize) //Some Developer leave paging to upper layers,
                .ToList();      //but paging is data access so should be done here in the Repository.
        }

        //Cast the Context as Specific Pluto Context & Return
        public PlutoContext PlutoContext
        {
            get { return Context as PlutoContext; }
        }
    }
}