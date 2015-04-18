using IdentityAccess.Core.Application.Commands;
using IdentityAccess.Core.Domain.Model;
using IdentityAccess.Core.Domain.Model.Event;
using IdentityAccess.Core.Domain.Model.Repository;
using SharedKernel.Domain.Model;

namespace IdentityAccess.Core.Application
{
    public class IdentityApplicationService : IIdentityApplicationService
    {
        private ITenantRepository _tenantRepository;

        public IdentityApplicationService(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public User Register(RegisterUserCommand command)
        {
            var tenant = new Tenant(command.FullName, string.Empty);
            var user = tenant.RegisterFirstUser(command.UserName, command.Password, command.Email);

            if (tenant.IsValid() && user.IsValid())
            {
                _tenantRepository.Register(tenant, user);
                DomainEvents.Raise(new UserRegistered(user));
                return user;
            }

            return null;
        }
    }
}
