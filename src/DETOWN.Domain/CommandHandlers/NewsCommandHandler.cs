using System;
using System.Threading;
using System.Threading.Tasks;
using DETOWN.Domain.Commands;
using DETOWN.Domain.Core.Bus;
using DETOWN.Domain.Core.Notifications;
using DETOWN.Domain.Events;
using DETOWN.Domain.Interfaces;
using DETOWN.Domain.Models;
using MediatR;

namespace DETOWN.Domain.CommandHandlers
{
    public class NewsCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewsCommand, bool>
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMediatorHandler Bus;

        public NewsCommandHandler(INewsRepository newsRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _newsRepository = newsRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewsCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var news = new News(Guid.NewGuid(), message.Title, message.Header, message.PublicationDate, message.Description);

            if (_newsRepository.GetNewsByTitle(news.Title) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The news has already been taken."));
                return Task.FromResult(false);
            }

            _newsRepository.Add(news);

            if (Commit())
            {
                Bus.RaiseEvent(new NewsRegisteredEvent(news.Id, news.Title, news.Header, news.PublicationDate, news.Description));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _newsRepository.Dispose();
        }
    }
}
