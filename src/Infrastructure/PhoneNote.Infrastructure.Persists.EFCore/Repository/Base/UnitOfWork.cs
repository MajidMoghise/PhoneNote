using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhoneNote.Domain.Contract.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PhoneNote.Infrastructure.Persists.EFCore.Repository.Base
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public bool Disposed { get; set; } = false;

        public UnitOfWork(Ef_DbContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
           
        }

        public Ef_DbContext Context { get; }
        
        public async Task BeginTransactionAsync()
        {

            if (Context.Transaction == null)
            {
                Context.Transaction = await Context.Database.BeginTransactionAsync();
                Context.TransactionStatus = TransactionStatus.Active;
            }
            

        }
        public void BeginTransaction()
        {
            if (Context.Transaction == null)
            {
                Context.Transaction = Context.Database.BeginTransaction();
                Context.TransactionStatus = TransactionStatus.Active;
            }
           
        }


        public async Task CommitAsync()
        {
            if (Context.Transaction is not null && Context.TransactionStatus == TransactionStatus.Active)
            {
                await Context.Transaction.CommitAsync();
                Context.TransactionStatus = TransactionStatus.Committed;
                await Context.Transaction.DisposeAsync();
                Context.TransactionStatus = TransactionStatus.InDoubt;
                Disposed = true;
                Context.Transaction = null;
               
            }
            
        }
        public void Commit()
        {
            if (Context.Transaction is not null && Context.TransactionStatus == TransactionStatus.Active)
            {
                Context.Transaction.Commit();
                Context.TransactionStatus = TransactionStatus.Committed;
                Context.Transaction.Dispose();
                Context.TransactionStatus = TransactionStatus.InDoubt;
                Disposed = true;
                Context.Transaction = null;
            }
        }

        public void Dispose()
        {
            if (Context.Transaction is not null)
            {
                Context.Transaction.Dispose();
                Context.TransactionStatus = TransactionStatus.InDoubt;
                Disposed = true;
            }
            
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {

                }
                else
                {
                    Context.Dispose();
                    }

            }

            Disposed = true;
        }


        public void TrackGraph(object rootEntity, Action<EntityEntryGraphNode> callback)
        {
            Context.ChangeTracker.TrackGraph(rootEntity, callback);
        }

        public void RollBack()
        {
            if (Context.Transaction is not null && Context.TransactionStatus == TransactionStatus.Active)
            {
                Context.Transaction?.Rollback();
                Context.TransactionStatus = TransactionStatus.Aborted;
            }
            
        }

        public async Task RollBackAsync()
        {
            if (Context.Transaction is not null && Context.TransactionStatus == TransactionStatus.Active)
            {
                await Context.Transaction?.RollbackAsync();
                Context.TransactionStatus = TransactionStatus.Aborted;
            }
           
        }


    }

}
