namespace PhoneNote.Domain.Contract.Contracts.Base.Models
{
    public class PagingRequestModel
    {
        public int PageSize { get; set; } = 5;
        public int Page { get; set; } = 1;
    }
}
