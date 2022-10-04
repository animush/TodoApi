using System.Security.Claims;
using ToDo.Services;

namespace TodoApi.Middlware
{
    public class ContextMiddleware
    {
        private readonly RequestDelegate _next;

        public ContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserContext userContext)
        {
            var claim = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.UserData);
            if(claim != null && int.TryParse(claim.Value, out var userId))
            {
                userContext.CurrentUserId =  userId;
            }

            await _next(context);
        }
}

    public static class ContextMiddlewareExtensions
    {
        public static IApplicationBuilder UseContextMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ContextMiddleware>();
        }
    }
}
