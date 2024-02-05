using PhoneNote.Domain.Contract.Contracts.People.Models;
using PhoneNote.Domain.Entities;
using PhoneNote.Domain.Enums;

namespace PhoneNote.Infrastructure.Persists.EFCore.Repository.People
{
    internal class PersonRepositoryMapper
    {
        internal Person Person(UpdatePersonRequestModel request)
        {
          return  new Person.Builder().Update(request.Id,request.NationalCode, request.Name, request.Email,  request.RowVersion, request.PersonTypeId);
        }

        internal PersonDetailRequestModel PersonDetailRequestModel(Person person)
        {
            return new PersonDetailRequestModel
            {
                Id = person.Id,
                CreateDate = person.CreateDate,
                UpdateDate = person.UpdateDate,
                PersonTypeId = person.PersonTypeId,
                PersonTypeName = Enum.GetName(typeof(PersonTypeEnum), person.PersonTypeId),
                NationalCode = person.NationalCode,
                Name = person.Name,
                RowVersion = person.RowVersion,
                IsDeleted = person.IsDeleted,
                Email = person.Email,
            };
        }
    }
}
