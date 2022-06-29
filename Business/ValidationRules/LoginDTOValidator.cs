using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules
{
    public class LoginDTOValidator:AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(x => x.IdentificationNumber).NotEmpty().Length(11);
            RuleFor(x => x.Password).NotEmpty().MaximumLength(10);
        }
    }
}
