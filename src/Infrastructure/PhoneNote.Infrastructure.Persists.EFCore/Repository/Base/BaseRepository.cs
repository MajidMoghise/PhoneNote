using Microsoft.EntityFrameworkCore;
using PhoneNote.Domain.Contract.Contracts.Base;
using PhoneNote.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNote.Infrastructure.Persists.EFCore.Persists.EFCore.Repository.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly Ef_DbContext _context;
        protected readonly DbSet<TEntity> _entity;

        protected readonly IUnitOfWork _unitOfWork;

        public BaseRepository(Ef_DbContext context,
                IUnitOfWork unitOfWork)
        {

            _context = context;
            _entity = _context.Set<TEntity>();
            _unitOfWork = unitOfWork;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _unitOfWork.BeginTransactionAsync();
            await _entity.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await _unitOfWork.BeginTransactionAsync();
            _entity.Remove(entity);
            await _context.SaveChangesAsync();
            
        }
    }
}
