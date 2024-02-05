using PhoneNote.Domain.Entities;
using PhoneNote.Domain.Contract.Contracts.Phones.Models;

namespace PhoneNote.Infrastructure.Persists.EFCore.Repository.Phones
{
    internal class PhoneRepositoryMapper
    {
        internal Phone Phone(UpdatePhoneRequestModel request)
        {
            return new Phone.Builder().Update(request.Id, request.PhoneNumber, request.RowVersion, request.PhoneType, request.PersonId);
        }

        internal PhoneDetailResponseModel PhoneDetailResponseModel(Phone phone)
        {
            return new PhoneDetailResponseModel
            {
                UpdateDate = phone.UpdateDate,
                RowVersion = phone.RowVersion,
                PhoneNumber = phone.PhoneNumber,
                CreateDate = phone.CreateDate,
                Id = phone.Id,
                IsDeleted = phone.IsDeleted,
                PersonId = phone.PersonId,
                PhoneTypeId = phone.PersonId
            };
        }
    }
}

