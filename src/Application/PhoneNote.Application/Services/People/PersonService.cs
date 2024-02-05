using PhoneNote.Application.Contract.Base.Dtos;
using PhoneNote.Application.Contract.Services.People;
using PhoneNote.Application.Contract.Services.People.Dtos;
using PhoneNote.Domain.Contract.Contracts.People;
using PhoneNote.Domain.Contract.Contracts.Phones;

namespace PhoneNote.Application.Services.People
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPhoneRepository _phoneRepository;
        private readonly PersonServiceMapper _mapper;
        public PersonService
            (
                IPersonRepository personRepository,
                IPhoneRepository phoneRepository
            )
        {
            _personRepository = personRepository;
            _phoneRepository = phoneRepository;
            _mapper = new PersonServiceMapper();
        }
        public async Task<CreatePersonResponseDto> CreatePerson(CreatePersonRequestDto request)
        {
            var model = _mapper.Person(request);
            var result = await _personRepository.CreateAsync(model);
            var modelPhone = _mapper.Phones(request.Phones, result.Id);
            var results = await _phoneRepository.CreateListAsync(modelPhone);
            return _mapper.CreatePersonResponseDto(result, results);
        }

        public async Task<DeletePersonResponseDto> DeletePerson(DeletePersonRequestDto request)
        {
            var modelForDelete = _mapper.Person(request);
            await _personRepository.DeleteAsync(modelForDelete);
            var phones = await _phoneRepository.GetPhonesOfPerson(request.PersonId);
            phones.ForEach(async item =>
            {
                var modelPhone = _mapper.Phone(item);
                await _phoneRepository.DeleteAsync(modelPhone);
            });
            return _mapper.DeletePersonResponseDto(request, phones);
        }

        public async Task<PagingResponseDto<PersonResponseDto>> GetPeople(PersonRequestDto request)
        {
            var model = _mapper.PersonRequestModel(request);
            var result = await _personRepository.GetAsync(model);
            return _mapper.PagingResponseDto_PersonResponseDto(result);
        }

        public async Task<PersonDetailResponseDto> GetPersonDetail(PersonDetailRequestDto request)
        {
            var result = await _personRepository.GetByIdAsync(request.Id);
            return _mapper.PersonDetailResponseDto(result);
        }

        public async Task UpdatePerson(UpdatePersonRequestDto request)
        {
            var model = _mapper.UpdatePersonRequestModel(request);
            await _personRepository.UpdateAsync(model);
        }
    }
Implemantaion UnitofWork Call to Godarzi.
}
