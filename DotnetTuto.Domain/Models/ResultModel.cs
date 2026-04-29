using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetTuto.Domain.Models
{
    public class ResultModel<T>
    {
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public EnumResponseType ResponseType { get; set; }

        public bool IsSuccess { get; set; }
        public bool IsError { get { return !IsSuccess; } }
        public T Data { get; set; }
    }
}
