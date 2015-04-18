using SharedKernel.Domain.Model;
using System;

namespace IdentityAccess.Core.Domain.Model
{
    public class Tenant : Entity
    {
        private TenantId _tenantId;

        public string Name { get; private set; }
        public bool Active { get; private set; }
        public DateTime Start { get; set; }

        protected Tenant() { }

        public Tenant(TenantId tenantId, string name, bool active)
        {
            _tenantId = tenantId;
            this.Id = tenantId.Id;
            this.Name = name;
            this.Active = active;
            this.Start = DateTime.Now;
        }

        public Tenant(string name, string description)
            : this(new TenantId(), name, true)
        {

        }

        public User RegisterUser(string username, string password, string email)
        {
            if (!this.Active) throw new InvalidOperationException("Tenant is not active.");

            return new User(_tenantId, username, password, email);
        }

        public User RegisterFirstUser(string username, string password, string email)
        {
            return new User(_tenantId, username, password, email);
        }

        public override bool IsValid()
        {
            return AssertionConcern.IsValid
            (
                AssertionConcern.AssertArgumentNotNull(_tenantId, "TenentId is required."),
                AssertionConcern.AssertArgumentNotEmpty(this.Name, "The tenant name is required."),
                AssertionConcern.AssertArgumentLength(this.Name, 1, 100, "The name must be 100 characters or less.")
            );
        }
    }
}
