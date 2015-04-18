using SharedKernel.Domain.Model.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Domain.Model
{
    public static class DomainEvents
    {
        public static IContainer Container { get; set; }
        
        public static void Raise<T>(T args) where T : IDomainEvent
        {
            try
            {
                if (Container != null)
                {
                    foreach (var handler in Container.GetServices(typeof(IHandles<T>)))
                        ((IHandles<T>)handler).Handle(args);
                }
            }
            catch
            {
                //throw;
            }
        }

        public static void Notify<T>(T args) where T : IDomainEvent
        {
            if (args == null) return;

            try
            {
                if (Container != null)
                {
                    foreach (var handler in Container.GetServices(typeof(IDomainNotificationHandle<T>)))
                        ((IDomainNotificationHandle<T>)handler).Handle(args);
                }
            }
            catch
            {
                //throw;
            }
        }
    }
}
