using GerenciadorDeViagem.API;
using GerenciadorDeViagem.API.Filters;
using GerenciadorDeViagem.Data;
using GerenciadorDeViagem.Data.Dal.Interfaces;
using GerenciadorDeViagem.Data.Dao;
using GerenciadorDeViagem.Data.Interfaces;
using GerenciadorDeViagemApi.Application;
using GerenciadorDeViagemApi.Infrastructure;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GerenciadorDeViagem
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            builder
                 .Services
                 .AddInfrastructure(configuration);

            builder
                .Services
                .AddApplicationsModules(  HttpResponseExceptionFilter
                                         .Create()
                                         .GetAwaiter()
                                         .GetResult()
                                       );

            builder
                .Services
                .AddSwaggerConfigurations();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}