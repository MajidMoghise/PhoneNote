namespace PhoneNote.Domain.Contract.Contracts.Base
{
    public interface IUnitOfWork
    {
        public bool Disposed { get; }
        Task BeginTransactionAsync();
        void BeginTransaction();
        void RollBack();
        Task RollBackAsync();
        Task CommitAsync();
        void Commit();
    }
}
