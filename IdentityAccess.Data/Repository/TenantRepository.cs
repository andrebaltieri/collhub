using IdentityAccess.Core.Domain.Model;
using IdentityAccess.Core.Domain.Model.Repository;
using IdentityAccess.Data.Context;
using SharedKernel.Domain.Model;

namespace IdentityAccess.Data.Repository
{
    public class TenantRepository: ITenantRepository
    {
        IdentityAccessDataContext _dataContext;

        public TenantRepository(IdentityAccessDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Register(Tenant tenant, User user)
        {
            _dataContext.Tenants.Add(tenant);
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
        }
    }
}
