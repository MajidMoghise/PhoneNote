namespace PhoneNote.Application.Contract.Services.People.Dtos
{
    public class DeletePersonRequestDto
    {
        public int PersonId { get; set; }
        public byte[] RowVersion{ get; set; }
    }

}
