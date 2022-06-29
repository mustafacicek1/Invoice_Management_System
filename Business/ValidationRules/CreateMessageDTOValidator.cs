using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules
{
    public class CreateMessageDTOValidator:AbstractValidator<CreateMessageDTO>
    {
        public CreateMessageDTOValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(350);
        }
    }
}
