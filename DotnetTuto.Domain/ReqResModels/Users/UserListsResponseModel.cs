using DotnetTuto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetTuto.Domain.ReqResModels.Users
{
    public class UserListsResponseModel 
    {
        public List<User>? users { get; set; }

        public ResponseModel Response { get; set; }
    }

    public class ResponseModel : BaseResponseModel
    {

    }
}
