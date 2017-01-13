using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Angular2.Leaning.Data;

namespace Angular2.Leaning.Repository
{
    public abstract class BaseRepository<TEntity> where TEntity : class
    {
        private readonly IDbContextProvider _dbContextProvider;
        protected AngularDbContext DbContext => _dbContextProvider.GetBudgItDbContext();
        protected BaseRepository(IDbContextProvider dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public TEntity Add(TEntity t)
        {
            DbContext.Set<TEntity>().Add(t);
            SafeSaveChanges();

            return t;
        }

        public void Edit(TEntity t)
        {
            var entry = DbContext.Entry(t);
            DbContext.Set<TEntity>().Attach(t);
            entry.State = EntityState.Modified;
            SafeSaveChanges();
        }

        public void Delete(Guid id )
        {
            DbContext.Set<TEntity>().Remove(Get(id));
        }
        public IEnumerable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return DbContext.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(Guid id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public TEntity Get(int id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> GetPagingData(Expression<Func<TEntity, bool>> filter, int pageIndex, int pageSize, string orderByPropertyName, bool isAsc)
        {
            return DbContext.Set<TEntity>().Where(filter)
               // .SortByProperty(orderByPropertyName, isAsc)
                .Skip(pageSize * (pageIndex - 1))
                .Take(pageSize)
                .AsQueryable();
        }

        public IEnumerable<TEntity> GeyByFilter(Expression<Func<TEntity, bool>> filter)
        {
            return DbContext.Set<TEntity>().Where(filter);
        }
        public void SafeSaveChanges()
        {
            foreach (var error in DbContext.GetValidationErrors())
            {
                var entityType = error.Entry.Entity.GetType().BaseType;

                foreach (var validationError in error.ValidationErrors)
                {
                    var property = entityType.GetProperty(validationError.PropertyName);
                    if (property.GetCustomAttributes(typeof(RequiredAttribute), true).Any())
                    {
                        property.GetValue(error.Entry.Entity, null);
                    }
                }
            }

            DbContext.SaveChanges();
        }

    }
}
