using PhoneNote.Application.Contract.Base.Dtos;
using PhoneNote.Application.Contract.Services.People.Dtos;

namespace PhoneNote.Application.Contract.Services.People
{
    public interface IPersonService
    {
        Task<PersonDetailResponseDto> GetPersonDetail(PersonDetailRequestDto request); 
        Task<CreatePersonResponseDto> CreatePerson(CreatePersonRequestDto request); 
        Task UpdatePerson(UpdatePersonRequestDto request);
        Task<DeletePersonResponseDto> DeletePerson(DeletePersonRequestDto request);
        Task<PagingResponseDto<PersonResponseDto>> GetPeople(PersonRequestDto request);
    }

}
