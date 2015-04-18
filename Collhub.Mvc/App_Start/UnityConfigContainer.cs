using Collhub.Mvc.Events;
using IdentityAccess.Core.Application;
using IdentityAccess.Core.Domain.Model.Event;
using IdentityAccess.Core.Domain.Model.Repository;
using IdentityAccess.Data.Context;
using IdentityAccess.Data.Repository;
using Microsoft.Practices.Unity;
using SharedKernel.Domain.Model;
using SharedKernel.Domain.Model.Event;
using System.Collections.Generic;

namespace Collhub.Mvc
{
    public static class UnityConfigContainer
    {
        public static UnityContainer Register()
        {
            var container = new UnityContainer();


            container.RegisterType<IdentityAccessDataContext, IdentityAccessDataContext>();
            container.RegisterType<ITenantRepository, TenantRepository>();
            container.RegisterType<IIdentityApplicationService, IdentityApplicationService>();
            container.RegisterType<IHandles<UserRegistered>, UserRegisteredHanle>();
            container.RegisterType<IDomainNotificationHandle<DomainNotification>, DomainNotificationHandle>(new HierarchicalLifetimeManager());

            return container;
        }
    }
}