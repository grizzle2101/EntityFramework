using Queries.Core.Domain;
using System.Collections.Generic;

namespace Queries.Core.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        //Task 3 - Inheriting from IRepository & provide Specific Course Methods.
        IEnumerable<Course> GetTopSellingCourses(int count);
        IEnumerable<Course> GetCoursesWithAuthors(int pageIndex, int pageSize);
    }
}