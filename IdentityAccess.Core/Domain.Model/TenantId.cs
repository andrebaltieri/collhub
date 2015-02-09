using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedKernel.Domain.Model;

namespace IdentityAccess.Core.Domain.Model
{
    public class TenantId : Identity
    {
        public TenantId()
            : base()
        {
        }

        public TenantId(string id)
            : base(id)
        {
        }
    }
}
