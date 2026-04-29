using Azure.Core;
using DotnetTuto.Database.Data;
using DotnetTuto.Domain.Interfaces;
using DotnetTuto.Domain.Models;
using DotnetTuto.Domain.ReqResModels.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetTuto.Database.Repositry
{
    public class UserRepositry : IUserRepositry
    {
        private readonly AppDbContext _context;

        public UserRepositry(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserListsResponseModel?> GetAllAsync()
        {
            var users = await _context.Users.AsNoTracking().ToListAsync();
            var model = new UserListsResponseModel()
            {
                users = users,
                Response = new ResponseModel
                {
                   ResponseCode = 200,
                   IsSuccess = true,
                   ResponseMessage = "Get All users",
                   ResponseType = EnumResponseType.Success,
                }
            };

            return model;
        }
    }
}
