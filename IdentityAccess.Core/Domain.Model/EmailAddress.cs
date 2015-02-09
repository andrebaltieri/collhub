using SharedKernel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityAccess.Core.Domain.Model
{
    public class EmailAddress : ValueObject
    {
        const string PATTERN = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

        public string Address { get; private set; }

        protected EmailAddress() { }

        public EmailAddress(string address)
        {
            AssertionConcern.AssertArgumentNotEmpty(address, "The email address is required.");
            AssertionConcern.AssertArgumentLength(address, 1, 100, "Email address must be 100 characters or less.");
            AssertionConcern.AssertArgumentMatches(PATTERN, address, "Email address format is invalid.");

            this.Address = address;
        }
    }
}
