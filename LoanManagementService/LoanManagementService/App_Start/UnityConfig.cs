using LoanCommon.Helper;
using LoanDAL;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.WebApi;

namespace LoanManagementService
{
    public static class UnityConfig
    {
        private static readonly UnityContainer container = new UnityContainer();

        public static void RegisterComponents()
        {

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ILogger, LoanManagementLogger>(new ContainerControlledLifetimeManager());

            // Inject ILogger in Constructor for logging exception in Loan Data access 
            container.RegisterType<ILoanDataAccess, LoanDataAccess>(new InjectionConstructor(container.Resolve<ILogger>()));

             GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        /// <summary>
        /// for resolving with type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

    }
}