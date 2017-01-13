using System.Web;
using Angular2.Leaning.Data;
using Angular2.Leaning.Repository.UnitOfWork;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Angular2.Leaning.Repository
{
    public class RepositoryInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyContaining<IDbContextProvider>()
                       .Where(x => x.Name.EndsWith("Repository"))
                       .WithService.DefaultInterfaces()
                       .LifestylePerWebRequest());
            container.Register(Component.For<IDbContextProvider>().ImplementedBy<DbContextProvider>().LifestylePerWebRequest());
            container.Register(Component.For<AngularDbContext>().LifestyleCustom<PerRequestLifeStyleManager>());
            container.Register(Component.For<IUnitOfWorkFactory>().ImplementedBy<UnitOfWorkFactory>().LifestylePerWebRequest());
            container.Register(Component.For<IUnitOfWork>().ImplementedBy<EntityFrameworkUnitOfWork>().LifestylePerWebRequest());
        }
    }

    public class PerRequestLifeStyleManager : ILifestyleManager
    {
        readonly ILifestyleManager _perWebRequestLifestyleManager;
        readonly ILifestyleManager _perThreadLifestyleManager;

        public PerRequestLifeStyleManager()
        {
            _perWebRequestLifestyleManager = new ScopedLifestyleManager(new WebRequestScopeAccessor());
            _perThreadLifestyleManager = new ScopedLifestyleManager(new ThreadScopeAccessor());
        }

        public void Init(IComponentActivator componentActivator, IKernel kernel, ComponentModel model)
        {
            _perWebRequestLifestyleManager.Init(componentActivator, kernel, model);
            _perThreadLifestyleManager.Init(componentActivator, kernel, model);
        }

        public bool Release(object instance)
        {
            return GetManager().Release(instance);
        }

        public object Resolve(CreationContext context, IReleasePolicy releasePolicy)
        {
            return GetManager().Resolve(context, releasePolicy);
        }

        public void Dispose()
        {
            GetManager().Dispose();
        }

        ILifestyleManager GetManager()
        {
            if (HttpContext.Current != null)
            {
                return _perWebRequestLifestyleManager;
            }

            return _perThreadLifestyleManager;
        }
    }
}
