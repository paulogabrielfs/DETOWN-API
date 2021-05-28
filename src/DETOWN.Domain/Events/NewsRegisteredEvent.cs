using System;
using DETOWN.Domain.Core.Events;

namespace DETOWN.Domain.Events
{
    public class NewsRegisteredEvent : Event
    {
        public NewsRegisteredEvent(Guid id, string title, string header, DateTime publicationDate, string description)
        {
            Id = id;
            Title = title;
            Header = header;
            PublicationDate = publicationDate;
            Description = description;
        }
        public Guid Id { get; set; }

        public string Title { get; private set; }

        public string Header { get; private set; }

        public DateTime PublicationDate { get; private set; }

        public string Description { get; private set; }
    }
}
