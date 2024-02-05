namespace PhoneNote.Application.Contract.Services.Phones.Dtos
{
    public class GetPhoneWithPhonesResponseDto
    {
        public int Id { get; set; }
        public string PhoneTypeName { get; set; }
        public string NationalCode { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<GetPhoneForPhoneResponseInternalDto> Phones{ get; set; }

    }
}
