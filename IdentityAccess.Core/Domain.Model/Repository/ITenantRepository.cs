using SharedKernel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAccess.Core.Domain.Model.Repository
{
    public interface ITenantRepository : IRepository<Tenant>
    {
        void Register(Tenant tenant, User user);
    }
}
