using System;
using DETOWN.Domain.Core.Models;

namespace DETOWN.Domain.Models
{
    public class News : EntityAudit
    {
        public News(Guid id, string title, string header, DateTime publicationDate, string description)
        {
            Id = id;
            Title = title;
            Header = header;
            PublicationDate = publicationDate;
            Description = description;
        }

        // Empty constructor for EF
        protected News() { }

        public string Title { get; private set; }

        public string Header { get; private set; }

        public DateTime PublicationDate { get; private set; }

        public string Description { get; private set; }
    }
}
