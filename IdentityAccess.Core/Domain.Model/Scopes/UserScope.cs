using IdentityAccess.Core.Domain.Model.Repository;
using SharedKernel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAccess.Core.Domain.Model.Scopes
{
    public static class UserScope
    {
        #region Validação

        public static bool IsValid(this User user)
        {
            return user.EmailAddress.IsValid() &&
            AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotEmpty(user.Username, "user name is required"),
                AssertionConcern.AssertNotEmpty(user.Password, "password is required")
            );
        }

        #endregion

        #region Criação

        public static User IfTenantIsActived(this User user, ITenantRepository tenantRepository)
        {
            if (user == null) return null;

            var tenant = tenantRepository.FindById(new TenantId(user.TenantId));

            return tenant.Active ? user : null;
        }

        #endregion
    }
}
