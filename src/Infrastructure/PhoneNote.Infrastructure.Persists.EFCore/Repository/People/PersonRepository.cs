using Microsoft.EntityFrameworkCore;
using PhoneNote.Domain.Contract.Contracts.Base;
using PhoneNote.Domain.Contract.Contracts.Base.Models;
using PhoneNote.Domain.Contract.Contracts.People;
using PhoneNote.Domain.Contract.Contracts.People.Models;
using PhoneNote.Domain.Entities;
using PhoneNote.Infrastructure.Persists.EFCore.Persists.EFCore.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNote.Infrastructure.Persists.EFCore.Repository.People
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        private readonly PersonRepositoryMapper _mapper;
        public PersonRepository(Ef_DbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            _mapper = new PersonRepositoryMapper();
        }

        public Task<PagingResponseModel<PersonDetailRequestModel>> GetAsync(PersonRequestModel request)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonDetailRequestModel> GetByIdAsync(int id)
        {
           return _mapper.PersonDetailRequestModel(await _entity.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id));
        }
        public async Task<GetPersonWithPhonesResponseModel> GetPersonWithPhones(int personId)
        {
            return await _entity.Select(s => new GetPersonWithPhonesResponseModel
            {
                Email = s.Email,
                Id = s.Id,
                IsDeleted = s.IsDeleted,
                Name=s.Name,
                NationalCode=s.NationalCode,
                PersonTypeName=s.PersonType.Name,
                Phones= (IEnumerable<GetPhoneForPersonResponseInternalModel>)s.Phones.ToList(),
            }).FirstOrDefaultAsync(p=>p.Id==personId);
        }
        public async Task UpdateAsync(UpdatePersonRequestModel request)
        {
            var ent = _mapper.Person(request); 
            _unitOfWork.BeginTransaction();
            var at = _entity.Attach(ent);

            at.Property(p => p.UpdateDate).IsModified = true;
           
            if(!String.IsNullOrEmpty(request.NationalCode))
            {
                at.Property(p => p.NationalCode).IsModified = true;
            }
            if(!String.IsNullOrEmpty(request.Email))
            {
                at.Property(p => p.Email).IsModified = true;
            }
            if(!String.IsNullOrEmpty(request.Name))
            {
                at.Property(p => p.Name).IsModified = true;
            }
            if(request.PersonTypeId.HasValue)
            {
                at.Property(p => p.PersonTypeId).IsModified = true;
            }
            
            await _context.SaveChangesAsync();
        }
    }
}
