using IdentityAccess.Core.Application.Commands;
using IdentityAccess.Core.Domain.Model;

namespace IdentityAccess.Core.Application
{
    public interface IIdentityApplicationService
    {
        User Register(RegisterUserCommand command);
    }
}
