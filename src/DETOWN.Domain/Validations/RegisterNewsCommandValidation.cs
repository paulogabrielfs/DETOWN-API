using DETOWN.Domain.Commands;

namespace DETOWN.Domain.Validations
{
    public class RegisterNewsCommandValidation : NewsValidation<RegisterNewsCommand>
    {
        public RegisterNewsCommandValidation()
        {
            ValidateTitle();
            ValidatePublicationDate();
            ValidateHeader();
            ValidateDescription();
        }
    }
}
