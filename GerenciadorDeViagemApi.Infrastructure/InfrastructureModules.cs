using GerenciadorDeViagemApi.Core.EmailTemplates;
using GerenciadorDeViagemApi.Core.Repositories;
using GerenciadorDeViagemApi.Core.Services;
using GerenciadorDeViagemApi.Infrastructure.Persistence.Repositories;
using GerenciadorDeViagemApi.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GerenciadorDeViagemApi.Infrastructure
{
    public static class InfrastructureModules
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddPersistence(configuration)
                .AddDependenciInjection()
                .AddJwtAuth(configuration);

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var getConnectionString = configuration.GetConnectionString("sqlServer");
            services.AddDbContext<GerenciadorDeViagemDbContext>(options =>
            {
                options.UseSqlServer(getConnectionString);
            });
            
            return services;
        }

        private static IServiceCollection AddDependenciInjection(this IServiceCollection services)
        {

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITravelRepository, TravelRepositry>();
            services.AddScoped<IHashPasswordServices, HashPasswordServices>();
            services.AddScoped<IAuthServices, AuthServices>();
            services.AddScoped<IEmailService, EmailServices>();
            services.AddScoped<IEmailServiceFactory,  EmailServiceFactory>();
            services.AddScoped<AlertaAlteracaoSenha>();
            services.AddScoped<PrimeiroAcesso>();
            services.AddScoped<RecuperacaoDeSenha>();

            return services;
        }

        private static IServiceCollection AddJwtAuth(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,

                      ValidIssuer = configuration["JwtToken:Issuer"],
                      ValidAudience = configuration["JwtToken:Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtToken:Key"]!))
                  };
              });

            return services;
        }


    }
}
