using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules
{
    public class CreateInvoiceDTOValidator:AbstractValidator<CreateInvoiceDTO>
    {
        public CreateInvoiceDTOValidator()
        {
            RuleFor(x => x.Month).NotEmpty().MaximumLength(10);
            RuleFor(x => x.InvoicePrice).NotEmpty().GreaterThan(0);
            RuleFor(x => x.InvoicePrice).NotEmpty().GreaterThan(0);
        }
    }
}
