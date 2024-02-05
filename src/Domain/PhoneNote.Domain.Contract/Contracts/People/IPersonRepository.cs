using PhoneNote.Domain.Contract.Contracts.Base;
using PhoneNote.Domain.Contract.Contracts.Base.Models;
using PhoneNote.Domain.Contract.Contracts.People.Models;
using PhoneNote.Domain.Entities;

namespace PhoneNote.Domain.Contract.Contracts.People
{
    public interface IPersonRepository:IBaseRepository<Person>
    {
        Task UpdateAsync(UpdatePersonRequestModel request);
        Task<PersonDetailRequestModel> GetByIdAsync(int id);
        Task<PagingResponseModel<PersonDetailRequestModel>> GetAsync(PersonRequestModel request);
        Task<GetPersonWithPhonesResponseModel> GetPersonWithPhones(int personId);                                            

    }
    
}
