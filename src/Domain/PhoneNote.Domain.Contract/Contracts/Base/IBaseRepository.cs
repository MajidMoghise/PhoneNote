using PhoneNote.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNote.Domain.Contract.Contracts.Base
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> CreateListAsync(IEnumerable<TEntity> entity);
        Task DeleteAsync(TEntity entity);
    }
}
