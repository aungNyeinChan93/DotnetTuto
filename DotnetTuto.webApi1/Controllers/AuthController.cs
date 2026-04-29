using DotnetTuto.consoleApp1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotnetTuto.webApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly EffortlessService _effortlessService;

        public AuthController(EffortlessService effortlessService)
        {
            _effortlessService = effortlessService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserRequestModel userRequestModel)
        {
            try
            {
                var user = UsersModel.users?.FirstOrDefault(u =>
                {
                   return u.Name == userRequestModel.Name && u.Password == userRequestModel.Password;
                });

                if (user is null)
                {
                    return Unauthorized();
                }

                var model = new UserLoginModel
                {
                    UserName = user.Name!,
                    SeesionId = Guid.NewGuid(),
                    SessionExp = DateTime.Now.AddMinutes(1),
                };

                var jsonStr = JsonConvert.SerializeObject(model);

                var result = _effortlessService.Encode(jsonStr);
                if (result is null)
                {
                    return Unauthorized();
                }
                return Ok(new UserLoginResponseModel { IsSuccess =true,Token= result});
            }
            catch (Exception err)
            {

                return StatusCode(500,err.Message);
            }
        }


        [HttpPost("isAuth")]
        public async Task<IActionResult> IsAuthorize(TokenRequestModel tokenModel)
        {
            try
            {
                if (tokenModel is null)
                {
                    return NotFound("Token Not Found");
                }

                var result = _effortlessService.Decode(tokenModel.Token);

                if (result is null)
                {
                    return Unauthorized();
                }

                var userLoginModel = JsonConvert.DeserializeObject<UserLoginModel>(result!);

                return Ok(new {success=true,result = userLoginModel });
            }
            catch (Exception err)
            {
                return StatusCode(500,err.Message);
            }
        }

        [HttpGet("users")]
        public async Task<IActionResult> Users([FromQuery] string token)
        {
            if (token is null)
            {
                return NotFound("Token Not Found");
            }

            var result = _effortlessService.Decode(token);

            if (result is null)
            {
                return Unauthorized();
            }

            var userLoginModel = JsonConvert.DeserializeObject<UserLoginModel>(result!);

            if (userLoginModel is  null)
            {
                return Unauthorized();
            }

            if (userLoginModel.SessionExp < DateTime.Now)
            {
                return Unauthorized("session expired!");
            }

            var users = UsersModel.users;

            return Ok(new { success = true, result = userLoginModel  ,users });
        }


    }

    public static class UsersModel
    {
        public static List<User2>? users { get; set; } = new List<User2>()
        {
            new User2{Name = "user",Password = "123123"},
            new User2{Name = "admin",Password = "123123"}
        };
    }

    public class User2
    {
        public string? Name { get; set; }
        public string?  Password { get; set; }
    }

    public class UserRequestModel
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
    }

    public class UserLoginResponseModel
    {
        public string Token { get; set; }

        public bool IsSuccess { get; set; }


    }

    public class UserLoginModel 
    {
        public string UserName { get; set; }

        public Guid SeesionId { get; set; }

        public DateTime SessionExp { get; set; }
    }


    public class TokenRequestModel
    {
        public string Token { get; set; }
    }
}
