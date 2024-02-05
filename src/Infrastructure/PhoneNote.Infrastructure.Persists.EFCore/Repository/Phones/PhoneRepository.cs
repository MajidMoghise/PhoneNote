using Microsoft.EntityFrameworkCore;
using PhoneNote.Domain.Contract.Contracts.Base.Models;
using PhoneNote.Domain.Contract.Contracts.Base;
using PhoneNote.Domain.Contract.Contracts.People;
using PhoneNote.Domain.Contract.Contracts.People.Models;
using PhoneNote.Domain.Contract.Contracts.Phones;
using PhoneNote.Domain.Entities;
using PhoneNote.Infrastructure.Persists.EFCore.Persists.EFCore.Repository.Base;
using PhoneNote.Infrastructure.Persists.EFCore.Repository.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneNote.Domain.Contract.Contracts.Phones.Models;

namespace PhoneNote.Infrastructure.Persists.EFCore.Repository.Phones
{
    internal class PhoneRepository: BaseRepository<Phone>, IPhoneRepository
    {
        private readonly PhoneRepositoryMapper _mapper;
        public PhoneRepository(Ef_DbContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
            _mapper = new PhoneRepositoryMapper();
        }

        public Task<PagingResponseModel<PhoneDetailResponseModel>> GetAsync(PhoneRequestModel request)
        {
            throw new NotImplementedException();
        }

        public async Task<PhoneDetailResponseModel> GetByIdAsync(int id)
        {
            return _mapper.PhoneDetailResponseModel(await _entity.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id));
        }

        public async Task<List<PhoneResponseModel>> GetPhonesOfPerson(int personId)
        {
           return await _entity.AsNoTracking().Select(s => new PhoneResponseModel
            {
                PersonId = s.PersonId,
                PhoneNumber = s.PhoneNumber,
                PhoneTypeId = s.PhoneTypeId,
                PhoneTypeName = s.PhoneType.Name,
                PhoneId=s.Id,
                RowVersion=s.RowVersion,
            }).ToListAsync();
        }

        public async Task<GetPhoneWithPersonResponseModel> GetPhoneWithPhones(int phoneId)
        {
            return await _entity.Select(s => new GetPhoneWithPersonResponseModel
            {
                Email = s.Person.Email,
                Id = s.Id,
                IsDeleted = s.IsDeleted,
                PersonName = s.Person.Name,
                NationalCode = s.Person.NationalCode,
                PhoneTypeName = s.PhoneType.Name,
                PersonId=s.Person.Id,
                PersonTypeName=s.Person.PersonType.Name,
                PhoneNumber=s.PhoneNumber,
                RowVersion=s.RowVersion,
                UpdateDate=s.UpdateDate,
            }).FirstOrDefaultAsync(p=>p.Id==phoneId);
        }
        public async Task UpdateAsync(UpdatePhoneRequestModel request)
        {
            var ent = _mapper.Phone(request);
            _unitOfWork.BeginTransaction();
            var at = _entity.Attach(ent);

            at.Property(p => p.UpdateDate).IsModified = true;

            if (!String.IsNullOrEmpty(request.PhoneNumber))
            {
                at.Property(p => p.PhoneNumber).IsModified = true;
            }
            if (request.PhoneType.HasValue)
            {
                at.Property(p => p.PhoneTypeId).IsModified = true;
            }
            if (request.PersonId.HasValue)
            {
                at.Property(p => p.PersonId).IsModified = true;
            }
           

            await _context.SaveChangesAsync();
        }
    }
}

