using System.Data.Entity;
using FoveaExampleRepository.Core;

namespace FoveaExampleRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FoveaContext _db;

        public UnitOfWork(FoveaContext context)
        {
            _db = context;
        }

        public void Dispose()
        {
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public DbContext Db
        {
            get { return _db; }
        }
    }
}