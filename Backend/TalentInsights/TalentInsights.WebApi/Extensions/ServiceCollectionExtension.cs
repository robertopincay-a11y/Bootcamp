using Microsoft.AspNetCore.Mvc;
using Serilog;
using TalentInsights.Application.Helpers;
using TalentInsights.Application.Interfaces.Services;
using TalentInsights.Application.Services;
using TalentInsights.Domain.Database.SqlServer.Context;
using TalentInsights.Domain.Interfaces.Repositories;
using TalentInsights.Infrastructure.Persistence.SqlServer.Repositories;
using TalentInsights.Shared.Constants;
using TalentInsights.WebApi.Middlewares;

namespace TalentInsights.WebApi.Extensions
{
    public static class ServiceCollectionExtension
    {


        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICollaboratorService, CollaboratorServices>();
        }


        /// <summary>
        /// Metodo quesirve para anadir todos los repositorios
        /// </summary>
        /// <param name="services"></param>
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICollaboratorRepository, CollaboratorRepository>();
        }
        /// <summary>
        /// Metodo que anade lo escencial que necesita nuestra aplicacion para funcionar
        /// </summary>
        /// <param name="services"></param>
        public static void AddCore(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = (errorContext) =>
                {
                    var errors = errorContext.ModelState.Values.SelectMany(value => value.Errors.Select(error => error.ErrorMessage)).ToList();
                    var response = ResponseHelper.Create(
                        data: ValidationConstants.VALIDATION_MESSAGE,
                        errors: errors,
                        message: ValidationConstants.VALIDATION_MESSAGE);
                    return new BadRequestObjectResult(response);
                };
            });
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            services.AddOpenApi();

            //Database Connection
            services.AddSqlServer<TalentInsightsContext>(configuration.GetConnectionString("Database"));
            //servicios
            services.AddServices();
            //Repositorios
            services.AddRepositories();
            //Middleware
            services.AddMiddleware();

            AddLogging(services);
        }

        public static void AddMiddleware(this IServiceCollection services)
        {
            services.AddScoped<ErrorHandlerMiddlerware>();
        }

        public static void AddLogging(this IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(Path.Combine(Directory.GetCurrentDirectory(), "log", "log.txt"), rollingInterval: RollingInterval.Day)
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}
