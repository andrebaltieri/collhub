using System.Collections.Generic;

namespace SharedKernel.Domain.Model.Event
{
    public interface IDomainNotificationHandle<T> : IHandles<T> where T: IDomainEvent
    {
        List<T> Notify();
        bool HasNotifications();
    }
}
