namespace PhoneNote.Domain.Contract.Contracts.Phones.Models
{
    public class PhoneResponseModel
    {
        public int PhoneId { get; set; }
        public int PhoneTypeId { get; set; }
        public string PhoneTypeName { get; set; }
        public string PhoneNumber { get;set; }
        public int PersonId { get; set; }
        public byte[] RowVersion{ get; set; }
    }
}
