using PhoneNote.Domain.Enums;
using PhoneNote.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PhoneNote.Domain.Entities
{
    public class Person : BaseEntity
    {
        private Person()
        {
                
        }
        public string NationalCode { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public int PersonTypeId { get; private set; }
        public PersonType PersonType { get; private set; }

        public ICollection<Phone> Phones{ get;private set; }
        public class Builder
        {
            public Person Create(string nationalCode, string name, string email, PersonTypeEnum personTypeId)
            {
                Validation(nationalCode, name, email, personTypeId);

                return new Person
                {
                    CreateDate = DateTime.UtcNow,
                    Email = email,
                    IsDeleted = false,
                    Name = name,
                    NationalCode = nationalCode,
                    PersonTypeId = (int)personTypeId
                };


            }
            private void Validation(string nationalCode, string name, string email, PersonTypeEnum? personTypeId=null)
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new DomainException("name must be not null");
                }
                if (string.IsNullOrEmpty(email))
                {
                    throw new DomainException("email must be not null");
                }
                if (string.IsNullOrEmpty(nationalCode))
                {
                    throw new DomainException("nationalCode must be not null");
                }
                if (!nationalCode.All(a => char.IsDigit(a)))
                {
                    throw new DomainException("nationalCode must be not letter");
                }
                if (personTypeId.HasValue)
                {
                    if (personTypeId == PersonTypeEnum.Individual)
                    {
                        if (nationalCode.Length != 10)
                        {
                            throw new DomainException("nationalCode is not valid");
                        }

                    }
                    else if (personTypeId == PersonTypeEnum.Legal)
                    {
                        if (nationalCode.Length != 11)
                        {
                            throw new DomainException("nationalCode is not valid");
                        }
                    }
                }
            }
            public Person Update(int id, string nationalCode, string name, string email,  byte[] rowVersion, PersonTypeEnum? personTypeId=null)
            {
                Validation(nationalCode, name, email, personTypeId);

                return new Person
                {
                    Email = email,
                    IsDeleted = false,
                    Name = name,
                    NationalCode = nationalCode,
                    PersonTypeId = personTypeId.HasValue?(int)personTypeId.Value:0,
                    Id=id,
                    RowVersion=rowVersion,
                    UpdateDate=DateTime.UtcNow
                };
            }
            
            public Person Delete(int id, byte[] rowVersion)
            {
                if (id < 1)
                {
                    throw new DomainException("id must be exsit");
                }
                return new Person
                {
                    UpdateDate = DateTime.UtcNow,
                    Id = id,
                    RowVersion = rowVersion,
                    IsDeleted=true
                };
            }
        }


    }
}
