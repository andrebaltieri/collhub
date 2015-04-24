using SharedKernel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAccess.Core.Domain.Model.Scopes
{
    public static class TenantScope
    {
        public static bool IsValid(this Tenant tenant, User user)
        {
            return user.IsValid() &&
            AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(tenant.Id, "TenentId is required."),
                AssertionConcern.AssertNotEmpty(tenant.Name, "The tenant name is required."),
                AssertionConcern.AssertLength(tenant.Name, 1, 100, "The name must be 100 characters or less.")
            );
        }
    }
}
