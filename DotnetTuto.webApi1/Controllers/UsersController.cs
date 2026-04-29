using DotnetTuto.Domain.Models;
using DotnetTuto.Domain.Services;
using DotnetTuto.webApi1.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetTuto.webApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly UserService _userService;

        private readonly ResponseHelper _resHelper;

        public UsersController(UserService userService, ResponseHelper resHelper)
        {
            _userService = userService;
            _resHelper = resHelper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var model = await _userService.GetAllUsersAsync();

                //var result =  await new ResponseHelper().Execute(model!);
                var result = await _resHelper.Execute(model!);

                return result;
               
            }
            catch (Exception err)
            {
                return StatusCode(500, err.Message);
            }
        }
    } 
}
