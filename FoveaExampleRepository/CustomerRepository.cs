using FoveaExampleRepository.Core;
using FoveaExampleRepository.Entities;

namespace FoveaExampleRepository
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(IUnitOfWork unit)
            : base(unit)
        {
        }
    }
}