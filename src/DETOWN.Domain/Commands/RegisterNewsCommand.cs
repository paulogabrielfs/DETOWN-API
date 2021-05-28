using System;
using DETOWN.Domain.Validations;


namespace DETOWN.Domain.Commands
{
    public class RegisterNewsCommand : NewsCommand
    {
        public RegisterNewsCommand(string title, string header, DateTime publicationDate, string description)
        {
            Title = title;
            Header = header;
            PublicationDate = publicationDate;
            Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewsCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}