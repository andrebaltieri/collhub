using System;
using SharedKernel.Domain.Model;

namespace IdentityAccess.Core.Domain.Model
{
    public class TenantId : Identity
    {
        public TenantId()
            : base()
        {
        }

        public TenantId(Guid id)
            : base(id)
        {
        }
    }
}
