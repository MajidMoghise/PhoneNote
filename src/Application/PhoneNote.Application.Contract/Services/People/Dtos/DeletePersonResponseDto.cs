namespace PhoneNote.Application.Contract.Services.People.Dtos
{
    public class DeletePersonResponseDto
    {
        public int PersonId { get; set; }
        public IEnumerable<DeletePersnInternalPhoneResponseDto> Phones{ get; set; }
    }

    public class DeletePersnInternalPhoneResponseDto
    {
        public int PhoneId { get; set; }
        public string PhoneNumber { get; set; }
    }

}
