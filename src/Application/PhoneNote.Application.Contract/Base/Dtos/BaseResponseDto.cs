namespace PhoneNote.Application.Contract.Base.Dtos
{
    public class BaseResponseDto<TDto>: BaseResponse
    {
        public TDto Data{ get; set; }
    }

}
