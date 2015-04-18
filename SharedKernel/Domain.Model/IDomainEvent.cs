using System;

namespace SharedKernel.Domain.Model
{
    public interface IDomainEvent
    {
        DateTime DateOccurred { get; }
    }
}
