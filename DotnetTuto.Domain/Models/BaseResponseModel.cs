using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetTuto.Domain.Models
{
    public abstract class BaseResponseModel 
    {
        public int ResponseCode { get; set; }

        public string ResponseMessage { get; set; } = string.Empty;

        public EnumResponseType ResponseType { get; set; }

        public bool IsSuccess { get; set; }
        //public bool IsError => !IsError;

        public bool IsError { get { return !IsSuccess; } }

    }

    public enum EnumResponseType
    {
        Success = 1,
        Fail,
        ValidationError,
        SystemEror
    }
    
}
