using Microsoft.OpenApi.Models;

namespace GerenciadorDeViagem.API
{
    public static class SwaggerModules
    {
        public static IServiceCollection AddSwaggerConfigurations(this IServiceCollection services)
        {

            services
                .SwaggerCofigurations();

            return services;
        }

        private static IServiceCollection SwaggerCofigurations(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Viagem.API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header usado o esquema Bearer."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                      new OpenApiSecurityScheme
                      {
                         Reference = new OpenApiReference
                         {
                              Type = ReferenceType.SecurityScheme,
                              Id = "Bearer"
                         }
                      },
                      new string[]{}
                    }
                });
            });

            return services;
        }
    }
}
