﻿using SharedKernel.Domain.Model;
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

        private bool _valid;

        public string Email { get; private set; }

        protected EmailAddress() { }

        public EmailAddress(string address)
        {
            this.Email = address;
        }

        public bool IsValid()
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotEmpty(this.Email, "The email address is required."),
                AssertionConcern.AssertLength(this.Email, 1, 100, "Email address must be 100 characters or less."),
                AssertionConcern.AssertMatches(PATTERN, this.Email, "Email address format is invalid.")
            );
        }
    }
}
