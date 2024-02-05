using PhoneNote.Domain.Enums;

namespace PhoneNote.Application.Contract.Services.People.Dtos
{
    public class CreatePersonRequestDto
    {
        public string NationalCode { get;  set; }
        public string Name { get;  set; }
        public string Email { get;  set; }
        public PersonTypeEnum PersonType { get;  set; }
        public IEnumerable<CreatePersonInternalPhoneRequestDto> Phones { get; set; }
    }
    public class CreatePersonInternalPhoneRequestDto
    {
        public PhoneTypeEnum PhoneType { get; set; }
        public string PhoneNumber { get; set; }
    }

}
