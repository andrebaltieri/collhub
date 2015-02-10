using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using SharedKernel.Domain.Model;

namespace Collhub.Mvc
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = UnityConfigContainer.Register();
            var resolver = new UnityDependencyResolver(container);

            DomainEvents.Container = new DomainEventsContainer(resolver);

            DependencyResolver.SetResolver(resolver);
        }
    }
}