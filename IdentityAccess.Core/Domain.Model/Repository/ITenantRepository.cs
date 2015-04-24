using SharedKernel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAccess.Core.Domain.Model.Repository
{
    public interface ITenantRepository
    {
        void Register(Tenant tenant, User user);
        User RetriveUser(string login, string password);
        Tenant FindById(TenantId tenantId);
    }
}
