using PhoneNote.Domain.Contract.Contracts.Base;
using PhoneNote.Domain.Contract.Contracts.Base.Models;
using PhoneNote.Domain.Contract.Contracts.Phones.Models;
using PhoneNote.Domain.Entities;

namespace PhoneNote.Domain.Contract.Contracts.Phones
{
    public interface IPhoneRepository:IBaseRepository<Phone>
    {
        Task UpdateAsync(UpdatePhoneRequestModel request);
        Task<PhoneDetailResponseModel> GetByIdAsync(int id);
        Task<PagingResponseModel<PhoneDetailResponseModel>> GetAsync(PhoneRequestModel request);
        Task<GetPhoneWithPersonResponseModel> GetPhoneWithPhones(int phoneId);
        Task<List<PhoneResponseModel>> GetPhonesOfPerson(int personId);
    }
}
