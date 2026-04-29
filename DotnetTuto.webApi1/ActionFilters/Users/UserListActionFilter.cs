using DotnetTuto.consoleApp1.Services;
using DotnetTuto.webApi1.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace DotnetTuto.webApi1.ActionFilters.Users
{
    public class UserListActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var authHeader = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (authHeader is null || string.IsNullOrEmpty(authHeader))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var _effortLessService = context.HttpContext.RequestServices.GetRequiredService<EffortlessService>();

            string decodedStr = _effortLessService!.Decode(authHeader)!; 

            var model = JsonConvert.DeserializeObject<UserLoginModel>(decodedStr!);

            if (model!.SessionExp < DateTime.Now)
            {
                context.Result = new ObjectResult("Session Expired") { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }

            await next();
        }

    }
}
