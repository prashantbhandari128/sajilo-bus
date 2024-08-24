using WebService.Middlewares;

namespace WebService.Extensions
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseHttpLog(this IApplicationBuilder builder) => builder.UseMiddleware<HttpLogMiddleware>();
    }
}
