using PhoneNote.Application.Contract.Base.Dtos;
using PhoneNote.Application.Contract.Services.Phones;
using PhoneNote.Application.Contract.Services.Phones.Dtos;

namespace PhoneNote.Application
{
    public class PhoneService : IPhoneService
    {
        public Task<CreatePhoneResponseDto> CreatePhone(CreatePhoneRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task<DeletePhoneResponseDto> DeletePhone(DeletePhoneRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task<PagingResponseDto<PhoneResponseDto>> GetPhones(PhoneRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task<PhoneDetailResponseDto> GetPhoneDetail(PhoneDetailRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task<UpdatePhoneResponseDto> UpdatePhone(UpdatePhoneRequestDto request)
        {
            throw new NotImplementedException();
        }

       
    }
}
