using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNote.Domain.Contract.Contracts.Base.Models
{
    public class PagingResponseModel<T>
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int TotalCount { get; set; }
        public int TotalPage { get; set; }
        public required IEnumerable<T> Data { get; set; }
    }
}
