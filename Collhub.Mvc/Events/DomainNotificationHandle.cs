using SharedKernel.Domain.Model;
using SharedKernel.Domain.Model.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Collhub.Mvc.Events
{
    public class DomainNotificationHandle : IDomainNotificationHandle<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandle()
        {
            if (HttpContext.Current.Items["InvalidDomainNotifications"] == null)
                HttpContext.Current.Items["InvalidDomainNotifications"] = new List<DomainNotification>();
        }

        public void Handle(DomainNotification args)
        {
            _notifications = GetValue();
            _notifications.Add(args);
            HttpContext.Current.Items["InvalidDomainNotifications"] = _notifications;
        }

        public List<DomainNotification> Notify()
        {
            return GetValue();
        }

        private List<DomainNotification> GetValue()
        {
            return (List<DomainNotification>)HttpContext.Current.Items["InvalidDomainNotifications"];
        }


        public bool HasNotifications()
        {
            return GetValue().Count > 0;
        }
    }
}