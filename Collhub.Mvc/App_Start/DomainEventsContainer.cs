using SharedKernel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity.Mvc5;

namespace Collhub.Mvc
{
    public class DomainEventsContainer: IContainer
    {
        private UnityDependencyResolver _resolver;

        public DomainEventsContainer(UnityDependencyResolver resolver)
        {
            _resolver = resolver;
        }

        public object GetService(Type serviceType)
        {
            return _resolver.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolver.GetServices(serviceType);
        }
    }
}