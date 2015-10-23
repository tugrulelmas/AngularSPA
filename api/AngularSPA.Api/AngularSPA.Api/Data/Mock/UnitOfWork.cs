using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularSPA.Api.Data.Mock
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepository repository;

        public UnitOfWork() {
            repository = new Repository();
        }

        public IRepository Repository {
            get { return repository; }
        }

        public void BeginTransaction() {
            throw new NotImplementedException();
        }

        public void CommitTransaction() {
            throw new NotImplementedException();
        }

        public void RollbackTransaction() {
            throw new NotImplementedException();
        }

        public void Dispose() {
            //CommitTransaction();
        }
    }
}