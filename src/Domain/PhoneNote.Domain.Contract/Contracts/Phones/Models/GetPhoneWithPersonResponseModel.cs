namespace PhoneNote.Domain.Contract.Contracts.Phones.Models
{
    public class GetPhoneWithPersonResponseModel
    {
        public int Id { get;  set; }
        public byte[] RowVersion { get;  set; }
        public DateTime? UpdateDate { get;  set; }
        public string PhoneNumber { get;  set; }
        public int? PersonId { get;  set; }
        public string PersonName { get; set; }
        public string PersonTypeName { get; set; }
        public string NationalCode { get; set; }
        public string Email { get; set; }
        public string PhoneTypeName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
