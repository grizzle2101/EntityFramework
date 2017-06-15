using Queries.Core;
using Queries.Core.Repositories;
using Queries.Persistence.Repositories;

namespace Queries.Persistence
{
    //Task 6 - Implmenting UnitOfWork
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlutoContext _context;

        //This UnitOfWork is specific to our Application, so we take in PlutoContext.
        public UnitOfWork(PlutoContext context)
        {
            _context = context;
            //Same Context for ALL Repositories.
            //Client will instansiate the Context, and access ALL Repositories
            Courses = new CourseRepository(_context);
            Authors = new AuthorRepository(_context);
        }
        //Implementing Courses & Properties
        public ICourseRepository Courses { get; private set; }
        public IAuthorRepository Authors { get; private set; }

        //Complete = Save Changes
        public int Complete()
        {
            return _context.SaveChanges();
        }

        //Dispose Context
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}