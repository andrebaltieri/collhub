using SharedKernel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAccess.Core.Domain.Model.Repositories
{
    public interface IUserRepository: IRepository<User>
    {
        void Register(User user);
    }
}
