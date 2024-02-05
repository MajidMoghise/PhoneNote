
namespace PhoneNote.Domain.Contract.Contracts.People.Models
{
    public class GetPersonWithPhonesResponseModel
    {
        public int Id { get; set; }
        public string PersonTypeName { get; set; }
        public string NationalCode { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public IEnumerable<GetPhoneForPersonResponseInternalModel> Phones{ get; set; }

    }
}
