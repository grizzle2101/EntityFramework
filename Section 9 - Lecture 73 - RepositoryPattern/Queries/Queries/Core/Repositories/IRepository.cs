using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Queries.Core.Repositories
{
    //Task 1 - Create IRepository Interface
    public interface IRepository<TEntity> where TEntity : class //Only Works with Entities
    {
        TEntity Get(int id); //Get Specific Entity
        IEnumerable<TEntity> GetAll(); //Get All in Collection
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate); //Find & Provide Predicate for Searching.

        //Generic Methods for handling Entities
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}