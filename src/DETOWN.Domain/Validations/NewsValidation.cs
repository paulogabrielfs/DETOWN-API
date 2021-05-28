using System;
using DETOWN.Domain.Commands;
using FluentValidation;

namespace DETOWN.Domain.Validations
{
    public abstract class NewsValidation<T> : AbstractValidator<T> where T : NewsCommand
    {
        protected void ValidateTitle()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Please ensure you have entered the Title")
                .Length(2, 100).WithMessage("The Title must have between 2 and 100 characters");
        }

        protected void ValidateHeader()
        {
            RuleFor(c => c.Header)
                .NotEmpty().WithMessage("Please ensure you have entered the Header")
                .MinimumLength(2).WithMessage("The Header must have 2 characters minimum");
        }

        protected void ValidateDescription()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Please ensure you have entered the Description")
                .MinimumLength(2).WithMessage("The Description must have 2 characters minimum");
        }

        protected void ValidatePublicationDate()
        {
            RuleFor(c => c.PublicationDate)
                .NotEmpty()
                .Must(EarlierThanNow)
                .WithMessage("The publication date must be earlier than now");
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected static bool EarlierThanNow(DateTime publicationDate)
        {
            return publicationDate <= DateTime.Now;
        }
    }
}
