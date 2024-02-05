using PhoneNote.Application.Contract.Base.Dtos;
using PhoneNote.Application.Contract.Services.People.Dtos;
using PhoneNote.Domain.Contract.Contracts.Base.Models;
using PhoneNote.Domain.Contract.Contracts.People.Models;
using PhoneNote.Domain.Contract.Contracts.Phones.Models;
using PhoneNote.Domain.Entities;
using PhoneNote.Domain.Enums;

namespace PhoneNote.Application.Services.People
{
    internal class PersonServiceMapper
    {
        internal CreatePersonResponseDto CreatePersonResponseDto(Person result, IEnumerable<Phone> phones)
        {
            return new CreatePersonResponseDto
            {
                Id = result.Id,
                Phones = phones.Select(s => new CreatePersonInternalPhoneResponseDto
                {
                    PhoneNumber = s.PhoneNumber,
                    PhoneTypeName = Enum.GetName(typeof(PhoneTypeEnum), s.PhoneTypeId).ToString()
                })

            };
        }

        internal DeletePersonResponseDto DeletePersonResponseDto(DeletePersonRequestDto request, List<PhoneResponseModel> phones)
        {
            return new DeletePersonResponseDto
            {
                PersonId = request.PersonId,
                Phones = phones.Select(s => new DeletePersnInternalPhoneResponseDto
                {
                    PhoneId = s.PhoneId,
                    PhoneNumber = s.PhoneNumber,
                })
            };
        }

        internal PagingResponseDto<PersonResponseDto> PagingResponseDto_PersonResponseDto(PagingResponseModel<PersonDetailRequestModel> result)
        {
            return new PagingResponseDto<PersonResponseDto>
            {
                Data = result.Data.Select(s => new PersonResponseDto
                {
                    CreateDate = s.CreateDate,
                    Email = s.Email,
                    Id = s.Id,
                    IsDeleted = s.IsDeleted,
                    Name = s.Name,
                    NationalCode = s.NationalCode,
                    PersonTypeId = s.PersonTypeId,
                    PersonTypeName = s.PersonTypeName,
                    RowVersion = s.RowVersion,
                    UpdateDate = s.UpdateDate
                }),
                Page = result.Page,
                PageSize = result.PageSize,
                TotalCount = result.TotalCount,
                TotalPage = result.TotalPage

            };
        }

        internal Person Person(CreatePersonRequestDto request)
        {
            return new Person.Builder().Create(request.NationalCode, request.Name, request.Email, request.PersonType);
        }

        internal Person Person(DeletePersonRequestDto request)
        {
            return new Person.Builder().Delete(request.PersonId, request.RowVersion);
        }

        internal PersonDetailResponseDto PersonDetailResponseDto(PersonDetailRequestModel result)
        {
            return new PersonDetailResponseDto
            {
                CreateDate = result.CreateDate,
                Id = result.Id,
                Email = result.Email,
                IsDeleted = result.IsDeleted,
                Name = result.Name,
                NationalCode = result.NationalCode,
                PersonTypeId = result.PersonTypeId,
                PersonTypeName = result.PersonTypeName,
                RowVersion = result.RowVersion,
                UpdateDate = result.UpdateDate
            };
        }

        internal PersonRequestModel PersonRequestModel(PersonRequestDto request)
        {
            throw new NotImplementedException();
        }

        internal Phone Phone(PhoneResponseModel item)
        {
            return new Phone.Builder().Delete(item.PhoneId, item.RowVersion);
        }

        internal IEnumerable<Phone> Phones(IEnumerable<CreatePersonInternalPhoneRequestDto> phones, int personId)
        {
            return phones.Select(s => new Phone.Builder().Create(s.PhoneNumber, s.PhoneType, personId));
        }

        internal UpdatePersonRequestModel UpdatePersonRequestModel(UpdatePersonRequestDto request)
        {
            return new UpdatePersonRequestModel
            {
                Email = request.Email,
                Id = request.Id,
                Name = request.Name,
                NationalCode = request.NationalCode,
                PersonTypeId = request.PersonTypeId,
                RowVersion = request.RowVersion
            };
        }
    }
}
