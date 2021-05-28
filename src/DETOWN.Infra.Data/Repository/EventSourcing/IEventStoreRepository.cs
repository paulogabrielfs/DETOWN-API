using System;
using System.Collections.Generic;
using DETOWN.Domain.Core.Events;

namespace DETOWN.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
