using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules
{
    public class CreateApartmentDTOValidator:AbstractValidator<CreateApartmentDTO>
    {
        public CreateApartmentDTOValidator()
        {
            RuleFor(x => x.Blok).NotEmpty();
            RuleFor(x => x.Type).NotEmpty().MaximumLength(3);
            RuleFor(x => x.FloorNumber).GreaterThan(0);
            RuleFor(x => x.ApartmentNo).GreaterThan(0);
            RuleFor(x => x.IsEmpty).Must(x => x == false || x == true);
            RuleFor(x => x.UserId).GreaterThan(0).When(x=>x.IsEmpty==false);
        }
    }
}
