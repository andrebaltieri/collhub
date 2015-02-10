﻿using IdentityAccess.Core.Domain.Model.Event;
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
        public string Username { get; private set; }
        public string Password { get; private set; }
        public EmailAddress EmailAddress { get; private set; }

        protected User() { }

        public User(TenantId tenantId, string userName, string passWord, string email)
        {
            AssertionConcern.AssertArgumentNotEmpty(userName, "user name is required");
            AssertionConcern.AssertArgumentNotEmpty(passWord, "password is required");

            this.Id = tenantId.Id;
            this.Username = userName;
            this.Password = passWord;
            this.EmailAddress = new EmailAddress(email);

            DomainEvents.Raise(new UserRegistered(this));
        }
    }
}
