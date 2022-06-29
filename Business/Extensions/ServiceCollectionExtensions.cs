using Business.Abstract;
using Business.APIServices;
using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Abstract;
using DataAccess.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<CreateApartmentDTOValidator>());
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IApartmentService, ApartmentManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IInvoiceService, InvoiceManager>();
            services.AddScoped<IPaymentService, PaymentManager>();
            services.AddScoped<IMessageService, MessageManager>();
            services.AddHttpClient<CreditCardService>();

            return services;
        }
    }
}
