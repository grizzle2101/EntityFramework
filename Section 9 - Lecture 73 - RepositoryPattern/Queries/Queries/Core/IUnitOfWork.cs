using Queries.Core.Repositories;
using System;

namespace Queries.Core
{
    //Task 5 - IUnitOfWork
    public interface IUnitOfWork : IDisposable
    {
        //Note we use ICourseRepository interface, this if for testability,
        //so we can Inject mock the interface & Properties in Unit Tests
        //Exposes our 2 Repositories
        ICourseRepository Courses { get; }
        IAuthorRepository Authors { get; }
        int Complete();
    }
}