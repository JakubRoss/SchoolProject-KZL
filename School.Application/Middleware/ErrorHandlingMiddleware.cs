using Microsoft.AspNetCore.Http;

namespace School.Application.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
			try
			{
				await next.Invoke(context);
			}
			catch (ResourceNotFoundException)
			{
				context.Response.StatusCode = 404;
				await context.Response.WriteAsync("Not Found");
			}
            catch (FormatException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Bad request");
            }
            catch (Exception)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("I have no idea what's wrong");
            }
        }
    }
}
