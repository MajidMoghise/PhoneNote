
using PhoneNote.Domain.Enums;

namespace PhoneNote.Application.Contract.Services.People.Dtos
{
    public class UpdatePersonRequestDto
    {
        public string NationalCode { get;  set; }
        public string Name { get;  set; }
        public string Email { get;  set; }
        public PersonTypeEnum? PersonTypeId { get;  set; }
        public int Id { get;  set; }
        public byte[] RowVersion { get;  set; }
    }

}
