using Angular2.Leaning.DomainService.Impl;
using Angular2.Leaning.Repository;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace Angular2.Leaning.DomainService.Installer
{
    public class DomainServiceInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(FromAssembly.Containing<RepositoryInstaller>());
            container.Register(Classes.FromAssemblyContaining<EmployeeService>().InSameNamespaceAs<EmployeeService>().LifestylePerWebRequest()
               .WithServiceAllInterfaces());
        }
    }
}
