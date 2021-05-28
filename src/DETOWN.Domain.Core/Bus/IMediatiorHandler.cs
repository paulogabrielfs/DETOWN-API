using System.Threading.Tasks;
using DETOWN.Domain.Core.Commands;
using DETOWN.Domain.Core.Events;

namespace DETOWN.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
