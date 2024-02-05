
using PhoneNote.Domain.Enums;

namespace PhoneNote.Application.Contract.Services.Phones.Dtos
{
    public class UpdatePhoneRequestDto
    {
        public string NationalCode { get;  set; }
        public string Name { get;  set; }
        public string Email { get;  set; }
        public PhoneTypeEnum? PhoneTypeId { get;  set; }
        public int Id { get;  set; }
        public byte[] RowVersion { get;  set; }
    }

}
