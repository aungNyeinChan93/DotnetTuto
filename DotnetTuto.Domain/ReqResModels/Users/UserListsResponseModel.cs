using DotnetTuto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetTuto.Domain.ReqResModels.Users
{
    public class UserListsResponseModel:BaseResponseModel
    {
        public List<User>? users { get; set; }
    }
}
