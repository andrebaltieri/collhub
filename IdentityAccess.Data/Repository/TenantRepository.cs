using IdentityAccess.Core.Domain.Model;
using IdentityAccess.Core.Domain.Model.Repository;
using IdentityAccess.Data.Context;
using SharedKernel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public IDataContext GetDataContext()
        {
            return (IDataContext)_dataContext;
        }
    }
}
