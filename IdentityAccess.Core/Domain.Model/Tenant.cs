using SharedKernel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAccess.Core.Domain.Model
{
    public class Tenant : Entity
    {
        public TenantId TenantId { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }
        public DateTime Start { get; set; }

        protected Tenant() { }

        public Tenant(TenantId tenantId, string name, string description, bool active)
        {
            AssertionConcern.AssertArgumentNotNull(tenantId, "TenentId is required.");
            AssertionConcern.AssertArgumentNotEmpty(name, "The tenant name is required.");
            AssertionConcern.AssertArgumentLength(name, 1, 100, "The name must be 100 characters or less.");

            this.TenantId = tenantId;
            this.Name = name;
            this.Active = active;
        }

        public Tenant(string name, string description)
            : this(new TenantId(), name, description, true)
        {

        }

        public User RegisterUser(string username, string password, string email)
        {
            AssertionConcern.AssertStateTrue(this.Active, "Tenant is not active.");
            return new User(this.TenantId, username, password, email);
        }
    }
}
