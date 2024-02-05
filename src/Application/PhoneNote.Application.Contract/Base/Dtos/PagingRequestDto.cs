using System.Collections.Generic;

namespace PhoneNote.Application.Contract.Base.Dtos
{
    public class PagingRequestDto
    {
        public int PageSize { get; set; } = 5;
        public int Page { get; set; } = 1;
    }

}
