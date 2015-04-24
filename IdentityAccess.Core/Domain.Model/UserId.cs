using SharedKernel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAccess.Core.Domain.Model
{
    public class UserId: Identity
    {
        public UserId()
            : base()
        {
        }

        public UserId(Guid id)
            : base(id)
        {
        }
    }
}
