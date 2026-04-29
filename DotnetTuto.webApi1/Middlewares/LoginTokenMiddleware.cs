using DotnetTuto.consoleApp1.Services;
using DotnetTuto.webApi1.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotnetTuto.webApi1.Middlewares
{
    public class LoginTokenMiddleware
    {
        private readonly RequestDelegate _next;

        //private readonly List<string> publicRoutes = new List<string>()
        //{
        //    "/",
        //    "/weatherforecast",
        //    "/api/auth/login"
        //};

        private readonly HashSet<string> publicRoutes = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "/",
            "/weatherforecast",
            "/api/auth/login"
        };

        public LoginTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            if (this.publicRoutes.Contains(context.Request.Path))
            {
                //await _next(context)
                goto Result;
            }

            var authHeader = context.Request.Headers["Authorization"].ToString();
            if (authHeader is null || string.IsNullOrEmpty(authHeader))
            {
                context.Response.StatusCode = 401;
                return;
            }

            var effortlessService = context.RequestServices.GetRequiredService<EffortlessService>();
            var str = effortlessService.Decode(authHeader);
            UserLoginModel model = JsonConvert.DeserializeObject<UserLoginModel>(str!)!;

            if (model.SessionExp < DateTime.Now)
            {
                context.Response.StatusCode = 401;
                return;
            }

            Result:
            await _next(context);

        }
    }
}
