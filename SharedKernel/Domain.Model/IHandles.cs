using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Domain.Model
{
    public interface IHandles<T> where T : IDomainEvent
    {
        void Handle(T args);
    }
}
