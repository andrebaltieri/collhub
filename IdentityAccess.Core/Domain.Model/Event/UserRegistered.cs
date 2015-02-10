using SharedKernel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAccess.Core.Domain.Model.Event
{
    public class UserRegistered : IDomainEvent
    {
        public DateTime DateOccurred { get; private set; }
        public User UserCreated { get; private set; }

        public UserRegistered(User user, DateTime dateOccured)
        {
            this.UserCreated = user;
            this.DateOccurred = DateTime.Now;
        }

        public UserRegistered(User user) : this(user, DateTime.Now) { }
    }
}
