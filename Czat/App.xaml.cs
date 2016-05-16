using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Czat.RestApiService;
using Czat.RestApiService.Services;
using Czat.Views;

namespace Czat
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            InicializeIoC();

            LoginVM loginVm = IoC.Resolve<LoginVM>();
            loginVm.Show();
        }

        private static void InicializeIoC()
        {
            var container = new WindsorContainer();
            // add ability for resolving IEnumerable<IService>
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            RegisterServices(container);
            RegisterViews(container);
            IoC.Initialize(container);
        }

        private static void RegisterServices(WindsorContainer container)
        {
            container.Register(
                Component.For<ApiClient>()
                    .DependsOn(Dependency.OnValue("apiUrl", ConfigurationManager.AppSettings["ApiBaseUrl"]))
                    .LifestyleSingleton(),
                Component.For<UserRestService>().LifestyleSingleton()
                );
        }

        private static void RegisterViews(WindsorContainer container)
        {
            container.Register(
                Classes
                    .FromAssemblyInThisApplication()
                    .BasedOn(typeof(Window))
                    .LifestyleTransient()
                );
        }
    }
}