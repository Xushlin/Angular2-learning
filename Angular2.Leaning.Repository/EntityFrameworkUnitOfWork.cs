using System;
using System.Data.Entity;
using Angular2.Leaning.Repository.UnitOfWork;

namespace Angular2.Leaning.Repository
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;

        public EntityFrameworkUnitOfWork(IDbContextProvider dbProvider)
        {
            _dbContext = dbProvider.GetBudgItDbContext();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
            GC.SuppressFinalize(this);
        }
    }
}
