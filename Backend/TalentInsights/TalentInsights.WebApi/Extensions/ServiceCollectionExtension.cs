using TalentInsights.Application.Interfaces.Services;
using TalentInsights.Application.Services;
using TalentInsights.Domain.Database.SqlServer.Context;
using TalentInsights.Domain.Interfaces.Repositories;
using TalentInsights.Infrastructure.Persistence.SqlServer.Repositories;
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

            services.AddControllers();
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
        }

        public static void AddMiddleware(this IServiceCollection services)
        {
            services.AddScoped<ErrorHandlerMiddlerware>();
        }
    }
}
