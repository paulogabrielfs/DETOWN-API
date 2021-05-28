using System.Threading;
using System.Threading.Tasks;
using DETOWN.Domain.Events;
using MediatR;

namespace DETOWN.Domain.EventHandlers
{
    public class NewsEventHandler :
        INotificationHandler<NewsRegisteredEvent>
    {
        public Task Handle(NewsRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }
    }
}
