using DotnetTuto.Domain.Interfaces;
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
    }
}
