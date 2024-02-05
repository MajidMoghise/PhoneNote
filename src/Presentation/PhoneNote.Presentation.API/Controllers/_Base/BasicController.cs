
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PhoneNote.Application.Contract.Base.Dtos;

namespace PhoneNote.Presentation.API.Controllers._Base
{

    // [ApiController]
    public class BasicController : ControllerBase
    {
        const string OperationHasBeenSuccessful = "Operation has been successful";
        public BasicController()
        {

        }
        [NonAction]
        public OkObjectResult OkResult<TResult>([ActionResultObjectValue] TResult value) where TResult : BaseResponse
        {
            var result = new BaseResponseDto<TResult> { Data = value, Message = OperationHasBeenSuccessful };
            return new OkObjectResult(result);

        }
        [NonAction]
        public OkObjectResult OkResult<TResult>([ActionResultObjectValue] IEnumerable<TResult> value) where TResult : BaseResponse
        {
            var result = new PagingResponseDto<TResult> { Data = value, Message = OperationHasBeenSuccessful };
            return new OkObjectResult(result);

        }
        [NonAction]
        public OkObjectResult OkResult()
        {
            var result = new BaseResponse { Message = OperationHasBeenSuccessful };
            return new OkObjectResult(result);

        }

    }
}
