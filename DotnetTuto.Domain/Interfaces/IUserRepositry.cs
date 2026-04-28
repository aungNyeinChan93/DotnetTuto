using DotnetTuto.Domain.ReqResModels.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetTuto.Domain.Interfaces
{
    public interface IUserRepositry
    {
        Task<UserListsResponseModel?> GetAllAsync();

    }
}
