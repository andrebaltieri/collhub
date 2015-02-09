using IdentityAccess.Core.Domain.Model.Events;
using SharedKernel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAccess.Core.Domain.Model
{
    public class User : Entity
    {
        public TenantId TenantId { get; private set; }
        public string UserName { get; private set; }
        public string PassWord { get; private set; }
        public EmailAddress EmailAddress { get; private set; }

        protected User() { }

        public User(TenantId tenantId, string userName, string passWord, string email)
        {
            AssertionConcern.AssertArgumentNotEmpty(userName, "user name is required");
            AssertionConcern.AssertArgumentNotEmpty(passWord, "password is required");

            this.TenantId = tenantId;
            this.UserName = userName;
            this.PassWord = passWord;
            this.EmailAddress = new EmailAddress(email);

            DomainEvents.Raise(new UserRegistered(this));
        }
    }
}
