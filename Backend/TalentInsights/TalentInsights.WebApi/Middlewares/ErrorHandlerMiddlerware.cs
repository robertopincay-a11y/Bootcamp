
using TalentInsights.Domain.Exceptions;

namespace TalentInsights.WebApi.Middlewares
{
    public class ErrorHandlerMiddlerware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (NotFoundExceptions exception)
            {
                throw;
            }
        }
    }
}
