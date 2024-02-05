﻿
namespace PhoneNote.Application.Contract.Services.Phones.Dtos
{
    public class PhoneDetailRequestDto
    {
        public int PhoneTypeId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string PhoneTypeName { get; set; }
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string NationalCode { get; set; }
        public string Name { get; set; }
        public byte[] RowVersion { get; set; }
        public bool IsDeleted { get; set; }
        public string Email { get; set; }
    }
}
