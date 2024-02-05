namespace PhoneNote.Domain.Contract.Contracts.Phones.Models
{
    public class PhoneDetailResponseModel
    {
        public DateTime? UpdateDate { get; set; }
        public byte[] RowVersion { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int PersonId { get; set; }
        public int PhoneTypeId { get; set; }
    }
}
