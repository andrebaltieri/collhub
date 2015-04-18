using System;
using System.Collections.Generic;

namespace SharedKernel.Domain.Model
{
    public interface IContainer
    {
        object GetService(Type serviceType);
        IEnumerable<object> GetServices(Type serviceType);
    }
}
