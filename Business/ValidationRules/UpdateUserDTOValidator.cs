using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules
{
    public class UpdateUserDTOValidator:AbstractValidator<UpdateUserDTO>
    {
        public UpdateUserDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(30);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(100);
            RuleFor(x => x.IdentificationNumber).NotEmpty().Length(11);
            RuleFor(x => x.Phone).NotEmpty().Length(10);
            RuleFor(x => x.CarNumberPlate).NotEmpty().MinimumLength(4).MaximumLength(10).When(x => !string.IsNullOrEmpty(x.CarNumberPlate));
        }
    }
}
