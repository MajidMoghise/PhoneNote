using PhoneNote.Domain.Enums;

namespace PhoneNote.Application.Contract.Services.People.Dtos
{
    public class CreatePersonResponseDto
    {
        public int Id { get; set; }
        public IEnumerable<CreatePersonInternalPhoneResponseDto> Phones{ get; set; }
    }
    public class CreatePersonInternalPhoneResponseDto
    {
        public int Id { get; set; }
        public string PhoneTypeName{ get; set; }
        public string PhoneNumber { get; set; }
    }

}
