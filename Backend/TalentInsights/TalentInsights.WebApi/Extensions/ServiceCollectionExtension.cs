using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using TalentInsights.Application.Helpers;
using TalentInsights.Application.Interfaces.Services;
using TalentInsights.Application.Services;
using TalentInsights.Domain.Database.SqlServer.Context;
using TalentInsights.Domain.Exceptions;
using TalentInsights.Domain.Interfaces.Repositories;
using TalentInsights.Infrastructure.Persistence.SqlServer.Repositories;
using TalentInsights.Shared.Constants;
using TalentInsights.WebApi.Middlewares;

namespace TalentInsights.WebApi.Extensions
{
    public static class ServiceCollectionExtension
    {

        /// <summary>
		/// Método que sirve para añadir todos los servicios de la aplicación
		/// </summary>
		/// <param name="services"></param>
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICollaboratorService, CollaboratorServices>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICacheService, CacheService>();
        }


        /// <summary>
        /// Metodo quesirve para anadir todos los repositorios de la app
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
        public async static Task AddCore(this IServiceCollection services, IConfiguration configuration)
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
            var databaseConnectionString = Environment.GetEnvironmentVariable(ConfigurationConstants.CONNECTION_STRING_DATABASE)
                ?? configuration.GetConnectionString("Database");
            services.AddSqlServer<TalentInsightsContext>(configuration.GetConnectionString("Database"));
            //servicios
            services.AddServices();
            //Repositorios
            services.AddRepositories();
            //Middleware
            services.AddMiddleware();

            services.AddLogging();

            services.AddAuth(configuration);

            services.AddCache();

            await Initialize(services);
        }


        /// <summary>
		/// Método que añade los middlewares de la aplicación
		/// </summary>
		/// <param name="services"></param>
        public static void AddMiddleware(this IServiceCollection services)
        {
            services.AddScoped<ErrorHandlerMiddlerware>();
        }





        /// <summary>
        /// Metodo para añadir todo lo relacionado al logging
        /// </summary>
        /// <param name="services"></param>
        public static void AddLogging(this IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(Path.Combine(Directory.GetCurrentDirectory(), "log", "log.txt"), rollingInterval: RollingInterval.Day)
                .WriteTo.Console()
                .CreateLogger();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public async static Task Initialize(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var scope = provider.CreateAsyncScope();

            var collaboratorService = scope.ServiceProvider.GetRequiredService<ICollaboratorService>();
            await collaboratorService.CreateFirstUser();
        }

        public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(builder =>
            {
                builder.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                builder.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(builder =>
            {
                var tokenConfiguration = TokenHelper.Configuration(configuration);

                builder.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = tokenConfiguration.Issuer,
                    ValidateAudience = true,
                    ValidAudience = tokenConfiguration.Audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = tokenConfiguration.SecurityKey,
                    ClockSkew = TimeSpan.Zero
                };

                builder.Events = new JwtBearerEvents
                {
                    OnChallenge = async context =>
                    {
                        throw new UnauthorizedException(ResponseConstants.AUTH_TOKEN_NOT_FOUND);
                    }
                };
            });

            services.AddAuthorization();

        }

        public static void AddCache(this IServiceCollection services)
        {
            services.AddMemoryCache();
        }
    }
}
