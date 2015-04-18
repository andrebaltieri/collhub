using SharedKernel.Domain.Model;

namespace IdentityAccess.Core.Domain.Model
{
    public class User : Entity
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public EmailAddress EmailAddress { get; private set; }

        protected User() { }

        public User(TenantId tenantId, string userName, string password, string email)
        {
            this.Id = tenantId.Id;
            this.Username = userName;
            this.Password = password;
            this.EmailAddress = new EmailAddress(email);
        }

        public override bool IsValid()
        {
            return this.EmailAddress.IsValid() && AssertionConcern.IsValid
            (
                AssertionConcern.AssertArgumentNotEmpty(this.Username, "user name is required"),
                AssertionConcern.AssertArgumentNotEmpty(this.Password, "password is required")
            );
        }
    }
}
