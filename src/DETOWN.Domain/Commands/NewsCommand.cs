using System;
using DETOWN.Domain.Core.Commands;

namespace DETOWN.Domain.Commands
{
    public abstract class NewsCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Title { get; protected set; }

        public string Header { get; protected set; }

        public DateTime PublicationDate { get; protected set; }

        public string Description { get; protected set; }
    }
}
