using System.Data.Entity;
using FoveaExampleRepository.Entities;

namespace FoveaExampleRepository
{
    public class FoveaContext : DbContext
    {
        public FoveaContext()
            : base("name=FoveaExampleDbContext")
        {
        }

        public FoveaContext(string connectionString)
            : base(connectionString)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
    }
}