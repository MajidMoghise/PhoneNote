using PhoneNote.Domain.Enums;
using PhoneNote.Domain.Helper;

namespace PhoneNote.Domain.Entities
{
    public class Phone:BaseEntity
    {
        public int PhoneTypeId { get;private set; }
        public string PhoneNumber { get;private set; }
        public int PersonId { get;private set; }
        public Person Person { get; private set; }
        public PhoneType PhoneType{ get; private set; }

        private Phone()
        {
                
        }
        public class Builder
        {
            public Phone Create(string phoneNumber, PhoneTypeEnum phoneType, int personId)
            {

                if (String.IsNullOrEmpty(phoneNumber))
                {
                    throw new DomainException("PhoneNumber must be not null");
                }
                if (personId < 1)
                {
                    throw new DomainException("person id must be exsit");
                }

                return new Phone
                {
                    CreateDate = DateTime.UtcNow,
                    IsDeleted = false,
                    PhoneNumber = phoneNumber,
                    PersonId = personId,
                    PhoneTypeId = (int)phoneType,

                };
            }
            public Phone Update(int id, string phoneNumber,  byte[] rowVersion, PhoneTypeEnum? phoneType=null, int? personId=null)
            {
                if (id < 1)
                {
                    throw new DomainException("id must be exsit");
                }
                if (String.IsNullOrEmpty(phoneNumber))
                {
                    throw new DomainException("PhoneNumber must be not null");
                }
                if (personId.HasValue&&personId < 1)
                {
                    throw new DomainException("person id must be exsit");
                }

                return new Phone
                {
                    Id = id,
                    IsDeleted = false,
                    PersonId = personId.HasValue?personId.Value:0,
                    PhoneNumber = phoneNumber,
                    PhoneTypeId = phoneType.HasValue?(int)phoneType:0,
                    RowVersion = rowVersion,
                    UpdateDate = DateTime.UtcNow,

                };
            }
            public Phone UpdatePhoneNumber(int id, string phoneNumber, byte[] rowVersion)
            {
                if (id < 1)
                {
                    throw new DomainException("id must be exsit");
                }
                if (String.IsNullOrEmpty(phoneNumber))
                {
                    throw new DomainException("PhoneNumber must be not null");
                }
                return new Phone
                {
                    RowVersion = rowVersion,
                    UpdateDate = DateTime.UtcNow,
                    Id = id,
                    PhoneNumber = phoneNumber,
                };
            }
            public Phone Delete(int id, byte[] rowVersion)
            {
                if (id < 1)
                {
                    throw new DomainException("id must be exsit");
                }
                return new Phone
                {
                    Id = id,
                    UpdateDate = DateTime.UtcNow,
                    RowVersion = rowVersion,
                    IsDeleted = true,
                };
            }
            public Phone GetPhone(int id, string phoneNumber, byte[] rowVersion, int phoneTypeId, int personId, DateTime createDate, DateTime? updateDate, bool isDeleted)
            {
                return new Phone
                {
                    CreateDate = createDate,
                    Id = id,
                    IsDeleted = isDeleted,
                    PersonId = personId,
                    PhoneTypeId = phoneTypeId,
                    RowVersion = rowVersion,
                    UpdateDate = updateDate,
                    PhoneNumber = phoneNumber,

                };
            }
        }
    }
}
