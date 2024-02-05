namespace PhoneNote.Application.Contract.Services.People.Dtos
{
    public class GetPersonWithPhonesResponseDto
    {
        public int Id { get; set; }
        public string PersonTypeName { get; set; }
        public string NationalCode { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<GetPhoneForPersonResponseInternalDto> Phones{ get; set; }

    }
}
