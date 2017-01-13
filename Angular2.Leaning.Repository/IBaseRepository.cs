using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Angular2.Leaning.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity t);
        void Edit(TEntity t);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GeyByFilter(Expression<Func<TEntity, bool>> filter);
        TEntity Get(Guid id);
        TEntity Get(int id);
        void Delete(Guid id);
    }
}
