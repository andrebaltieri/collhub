using IdentityAccess.Core.Domain.Model;
using IdentityAccess.Core.Domain.Model.Repository;
using IdentityAccess.Core.Domain.Model.Scopes;
using IdentityAccess.Data.Context;
using SharedKernel.Domain.Model;
using System;
using System.Linq;

namespace IdentityAccess.Data.Repository
{
    public class TenantRepository : ITenantRepository
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

        public Tenant FindById(TenantId tenantId)
        {
            return this._dataContext.Tenants.Find(tenantId.Id);
        }

        public User RetriveUser(string login, string password)
        {
            var isAuthenticated = User.IsAuthenticated(login, password);
            var user = _dataContext.Users.FirstOrDefault(isAuthenticated);

            return user.IfTenantIsActived(this);
        }
    }
}
