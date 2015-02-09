using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using IdentityAccess.Core.Domain.Model;

namespace IdentityAccess.Tests.Unit
{
    [TestFixture]
    public class UserTests
    {
        private User user;

        [Test]
        [ExpectedException]
        public void throw_exception_when_user_name_is_null()
        {
            user = new User(new TenantId(), null, "user", "user@user.com");
        }

        [Test]
        [ExpectedException]
        public void throw_exception_when_user_name_is_empty()
        {
            user = new User(new TenantId(), "", "user", "user@user.com");
        }

        [Test]
        [ExpectedException]
        public void throw_exception_when_user_password_is_null()
        {
            user = new User(new TenantId(), "user", null, "user@user.com");
        }

        [Test]
        [ExpectedException]
        public void throw_exception_when_user_password_is_empty()
        {
            user = new User(new TenantId(), "user", "", "user@user.com");
        }

        [Test]
        [ExpectedException]
        public void throw_exception_when_user_email_is_null()
        {
            user = new User(new TenantId(), "user", "password", null);
        }

        [Test]
        [ExpectedException]
        public void throw_exception_when_user_email_is_empty()
        {
            user = new User(new TenantId(), "user", "password", "");
        }

        [Test]
        [ExpectedException]
        public void throw_exception_when_user_email_is_invalid()
        {
            user = new User(new TenantId(), "user", "password", "teste");
        }
    }
}
