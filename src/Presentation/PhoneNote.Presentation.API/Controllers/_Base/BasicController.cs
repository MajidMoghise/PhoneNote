using IDP.Application.Contract.Services.Base.Dtos;
using IDP.Application.Contract.Services.OIDCs.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace PhoneNote.Presentation.API.Controllers._Base
{

    // [ApiController]
    public class BasicController : ControllerBase
    {
        public BasicController()
        {

        }
        [NonAction]
        public OkObjectResult OkResult<TResult>([ActionResultObjectValue] TResult value) where TResult : IBaseResponseDto
        {
            var msg = Application.Resources.Resources.OperationIsSuccessFull;
            var result = new DataResponseDto<TResult> { Data = value, Message = msg };
            return new OkObjectResult(result);

        }
        [NonAction]
        public OkObjectResult OkResult<TResult>([ActionResultObjectValue] IEnumerable<TResult> value) where TResult : IBaseResponseDto
        {
            var msg = Application.Resources.Resources.OperationIsSuccessFull;
            var result = new ListDataResponseDto<TResult> { Data = value, Message = msg };
            return new OkObjectResult(result);

        }
        [NonAction]
        public OkObjectResult OkResult()
        {
            var msg = Application.Resources.Resources.OperationIsSuccessFull;
            var result = new ResponseDto { Message = msg };
            return new OkObjectResult(result);

        }

    }
}
