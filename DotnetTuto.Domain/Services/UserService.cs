using DotnetTuto.Domain.Interfaces;
using DotnetTuto.Domain.Models;
using DotnetTuto.Domain.ReqResModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetTuto.Domain.Services
{
    public class UserService
    {

        private readonly IUserRepositry _userRepositry;

        public UserService(IUserRepositry userRepositry)
        {
            _userRepositry = userRepositry;
        }

        public async Task<UserListsResponseModel?> GetAllUsersAsync()
        {
            var model = await _userRepositry.GetAllAsync();
            return model;
        }

        public async Task<ResultModel<User>> GetOneAsync(int id)
        {
            var user = await _userRepositry.GetOneUser(id);
            var model = new ResultModel<User>()
            {
                IsSuccess = true,
                ResponseCode = 200,
                ResponseMessage = "OK",
                ResponseType = EnumResponseType.Success,
                Data = user!
            };
            return model;
        }
    }
}
