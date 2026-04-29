using DotnetTuto.Domain.Models;
using DotnetTuto.Domain.ReqResModels.Users;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DotnetTuto.webApi1.Helpers
{
    public class ResponseHelper: ControllerBase
    {
        public async Task<IActionResult> Execute(object model)
        {
            var jObj = JObject.Parse(JsonConvert.SerializeObject(model));


            if (jObj.ContainsKey("Response"))
            {
                ResponseModel responseModel = JsonConvert.DeserializeObject<ResponseModel>(jObj["Response"]!.ToString()!)!;

                if (responseModel is null)
                {
                    return NotFound();
                }

                if (responseModel.ResponseType == EnumResponseType.ValidationError)
                {
                    return BadRequest();
                }

                if (responseModel.ResponseType == EnumResponseType.SystemEror)
                {
                    return StatusCode(500, model);
                }

                if (responseModel.ResponseType == EnumResponseType.Fail)
                {
                    return BadRequest();
                }

                return Ok(model);
            }

            return BadRequest(model);
        }

        public async Task<IActionResult> Execute<T>(ResultModel<T> model)
        {
            if (model is null)
            {
                return NotFound();
            }

            if (model.ResponseType == EnumResponseType.ValidationError)
            {
                return BadRequest();
            }
            if (model.ResponseType == EnumResponseType.SystemEror)
            {
                return StatusCode(500,model.ResponseMessage);
            }
            if (model.ResponseType == EnumResponseType.Success)
            {
                return Ok(model);
            }
            return BadRequest(model.ResponseMessage);
        }
    }
}
