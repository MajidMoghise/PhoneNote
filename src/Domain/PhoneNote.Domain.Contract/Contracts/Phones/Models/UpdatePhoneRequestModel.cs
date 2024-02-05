using PhoneNote.Domain.Enums;

namespace PhoneNote.Domain.Contract.Contracts.Phones.Models
{
    public class UpdatePhoneRequestModel
    {
        public int Id { get; protected set; }
        public byte[] RowVersion { get; protected set; }
        public DateTime? UpdateDate { get; protected set; }
        public string PhoneNumber { get; private set; }
        public int? PersonId { get; private set; }
        public PhoneTypeEnum? PhoneType { get; set; }
    }
}
