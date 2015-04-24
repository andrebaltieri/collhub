using SharedKernel.Domain.Model;
using System;

namespace IdentityAccess.Core.Domain.Model
{
    public class User : Entity
    {
        public Guid TenantId { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public EmailAddress EmailAddress { get; private set; }

        protected User() { }

        public static Func<User, bool> IsAuthenticated(string login, string pass)
        {
            return x => x.EmailAddress.Email == login && x.Password == pass;
        }

        public User(TenantId tenantId, string userName, string password, string email)
        {
            this.Id = new UserId().Id;
            this.TenantId = tenantId.Id;
            this.Username = userName;
            this.Password = password;
            this.EmailAddress = new EmailAddress(email);
        }

        public User(string email, string password) : this(null, string.Empty, password, email) { }
    }
}
