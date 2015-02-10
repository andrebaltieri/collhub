using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BetterSpecs;
using IdentityAccess.Core;
using IdentityAccess.Core.Domain.Model;
using SharedKernel.Domain.Model;
using IdentityAccess.Core.Domain.Model.Event;

namespace IdentityAccess.Tests.Spec
{
    [TestFixture]
    public class UserTest : SpecContext
    {
        private User user;
        private User expected;

        [SetUp]
        public void before_each()
        {
            DomainEvents.ClearCallbacks();
        }

        [Test]
        public void describe_register_user()
        {
            before = () => DomainEvents.Register<UserRegistered>(u => expected = u.UserCreated);

            context["when create a user"] = () =>
            {
                user = new User(new TenantId(), "teste", "master", "teste@123.com");

                it["prepares to notify"] = () => Assert.AreEqual(expected, user);
            };
        }


        [Test]
        public void descrive_register_invalide_user()
        {
            // TODO
        }

    }
}
