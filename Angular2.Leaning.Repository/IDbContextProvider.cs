using System;
using Angular2.Leaning.Data;
using Castle.Windsor;

namespace Angular2.Leaning.Repository
{
    public interface IDbContextProvider:IDisposable
    {
        AngularDbContext GetBudgItDbContext();
    }

    public class Disposable : IDisposable
    {
        private bool _isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                DisposeCore();
            }

            _isDisposed = true;
        }
        protected virtual void DisposeCore()
        {
        }
    }

    public class DbContextProvider : Disposable, IDbContextProvider
    {
        private readonly IWindsorContainer _container;

        public DbContextProvider(IWindsorContainer container)
        {
            _container = container;
        }

        public AngularDbContext GetBudgItDbContext()
        {
            return _container.Resolve<AngularDbContext>();
        }
    }
}
