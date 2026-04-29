using DotnetTuto.Domain.Services;
using DotnetTuto.webApi1.Helpers;
using Microsoft.AspNetCore.Mvc;
using DotnetTuto.Domain.Models;

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

                var result = await _resHelper.Execute(model!);

                return result;
            }
            catch (Exception err)
            {
                return StatusCode(500, err.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                var model = await _userService.GetOneAsync(id);
                if (model == null) return BadRequest();
                var responseModel = await _resHelper.Execute<User>(model);
                return Ok(model);
            }
            catch (Exception err)
            {
                return StatusCode(500, err.Message);
            }
        }
    } 
}
