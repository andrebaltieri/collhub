using IdentityAccess.Core.Application;
using IdentityAccess.Core.Domain.Model.Repository;
using IdentityAccess.Data.Context;
using IdentityAccess.Data.Repository;
using Microsoft.Practices.Unity;
using SharedKernel.Domain.Model;

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

            return container;
        }
    }
}