using IdentityAccess.Core.Application.Commands;
using IdentityAccess.Core.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAccess.Core.Application
{
    public interface IIdentityApplicationService
    {
        User Register(RegisterUserCommand command);
    }
}
