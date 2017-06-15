using Queries.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Queries.Persistence.Repositories
{
    //Task 2 - Implmenting Repository
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Get(int id)
        {
            // Here we are working with a DbContext, not PlutoContext. So we don't have DbSets 
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList(); //All Objects ToList()
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate); //Provide predicate, return result
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate); //Provide Predicate, return SingleOrDefault
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity); //Add Entity to Collection
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities); //Add List of Entities to Collection
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity); //Provide entity, remove enetity from collection
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);//Provide collection of  entities, remove entities from collection
        }
    }
}