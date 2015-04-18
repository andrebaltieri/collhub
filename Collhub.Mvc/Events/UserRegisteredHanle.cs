using IdentityAccess.Core.Domain.Model.Event;
using SharedKernel.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collhub.Mvc.Events
{
    public class UserRegisteredHanle: IHandles<UserRegistered>
    {
        public void Handle(UserRegistered args)
        {
            // Enviar Email
            Console.WriteLine("send email to " + args.UserCreated.EmailAddress.Email);
        }
    }
}