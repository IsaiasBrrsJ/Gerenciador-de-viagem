using FluentValidation;
using FluentValidation.AspNetCore;
using GerenciadorDeViagemApi.Application.Command.CreateUserCommand;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Filters;


namespace GerenciadorDeViagemApi.Application
{
    public static class ApplicationModules
    {
        public static IServiceCollection AddApplicationsModules(this IServiceCollection services, IActionFilter filter)
        {
            services
                .AddMediatR()
                .AddValidations()
                .AddFilters(filter);

            return services;
        }

        private static IServiceCollection AddMediatR(this IServiceCollection services)
        {

            services.
                 AddMediatR(ce => { ce.RegisterServicesFromAssemblies(typeof(CreateUserCommand).Assembly); });

            return services;
        }

        private static IServiceCollection AddValidations(this IServiceCollection services)
        {
            services
                .AddFluentValidationAutoValidation();

            services.AddValidatorsFromAssemblyContaining<CreateUserCommand>();

            return services;
        }
        private static IServiceCollection AddFilters(this IServiceCollection services, IActionFilter filter)
        {
            services
                .AddControllers(filters =>
                {
                    filters.Filters.Add(filter);
                })
                .ConfigureApiBehaviorOptions(x =>
                { 
                    x.SuppressModelStateInvalidFilter = true; 
                });

            return services;
        }

      
    }
}
