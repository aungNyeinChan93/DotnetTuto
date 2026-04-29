using DotnetTuto.webApi1.Middlewares;

namespace DotnetTuto.webApi1.Extensions
{
    public static class MiddlwareExtension
    {
        public static IApplicationBuilder MapMiddlewares(this IApplicationBuilder app)
        {
            app.UseMiddleware<LoginTokenMiddleware>();

            return app;
        }
    }
}
