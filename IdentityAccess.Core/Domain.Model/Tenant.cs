using SharedKernel.Domain.Model;
using System;

namespace IdentityAccess.Core.Domain.Model
{
    public class Tenant : Entity
    {
        public string Name { get; private set; }
        public bool Active { get; private set; }
        public DateTime Start { get; private set; }

        protected Tenant() { }

        public Tenant(TenantId tenantId, string name, bool active)
        {
            this.Id = tenantId.Id;
            this.Name = name;
            this.Active = active;
            this.Start = DateTime.Now;
        }

        public Tenant(string name, string description): this(new TenantId(), name, true)
        {

        }

        public User RegisterNewUser(string username, string password, string email)
        {
            if (!this.Active) throw new InvalidOperationException("Tenant is not active.");

            return new User(new TenantId(this.Id), username, password, email);
        }

        public User RegisterTenantUser(string username, string password, string email)
        {
            return new User(new TenantId(this.Id), username, password, email);
        }
    }
}
