using PhoneNote.Application.Contract.Base.Dtos;
using PhoneNote.Application.Contract.Services.Phones.Dtos;

namespace PhoneNote.Application.Contract.Services.Phones
{
    public interface IPhoneService
    {
        Task<PhoneDetailResponseDto> GetPhoneDetail(PhoneDetailRequestDto request); 
        Task<CreatePhoneResponseDto> CreatePhone(CreatePhoneRequestDto request); 
        Task<UpdatePhoneResponseDto> UpdatePhone(UpdatePhoneRequestDto request);
        Task<DeletePhoneResponseDto> DeletePhone(DeletePhoneRequestDto request);
        Task<PagingResponseDto<PhoneResponseDto>> GetPhones(PhoneRequestDto request);
    }

}
