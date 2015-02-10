using IdentityAccess.Core.Application.Commands;
using IdentityAccess.Core.Domain.Model;
using IdentityAccess.Core.Domain.Model.Repository;

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
            var user = tenant.RegisterUser(command.UserName, command.Password, command.Email);

            var context = _tenantRepository.GetDataContext();
            _tenantRepository.Register(tenant, user);
            context.Commit();

            return user;
        }
    }
}
