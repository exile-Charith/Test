using System.Configuration;
using System.Data.Entity;
using System.Linq;
using FoveaExampleRepository;
using FoveaExampleRepository.Core;
using FoveaExampleRepository.Entities;
using FoveaExampleRepository.Seed;
using NUnit.Framework;

namespace FoveaExampleRestfulApplicationTest
{
    [TestFixture]
    public class CustomerNonQueryTests
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerNonQueryTests()
        {
            var connectionString =
                ConfigurationManager.ConnectionStrings["FoveaExampleTestDbContext"].ConnectionString;
            _unitOfWork = new UnitOfWork(new FoveaContext(connectionString));
        }

        [TestFixtureSetUp]
        public static void Initialize()
        {
            Database.SetInitializer(new FoveaDbInitializer());
        }

        [Test]
        public void Single_CustomerId_ReturnCustomerIfExist()
        {
            var repository = new CustomerRepository(_unitOfWork);
            var customer = repository.Single(1);

            Assert.AreEqual(1, customer.Id);
            Assert.AreEqual("Test address 1", customer.Address);
            Assert.IsNotNullOrEmpty(customer.CustomerName);
            Assert.AreEqual(1, customer.CustomerNumber);
            Assert.AreEqual("0712451148", customer.Telephone);
        }

        [Test]
        public void Single_CustomerId_ReturnNullIfNotExist()
        {
            var repository = new CustomerRepository(_unitOfWork);
            var customer = repository.Single(100000);

            Assert.IsNull(customer);
        }

        [Test]
        public void GetAll_ReturnAllCustomers()
        {
            var repository = new CustomerRepository(_unitOfWork);
            var customers = repository.GetAll();
            Assert.IsNotNull(customers);
            Assert.LessOrEqual(1, customers.Count());
        }

        [Test]
        public void Insert_NewCustomer_ReturnNewCustomerId()
        {
            var repository = new CustomerRepository(_unitOfWork);

            var customer = new Customer
            {
                Address = "Test address 4",
                CustomerName = "Customer 4",
                CustomerNumber = 4,
                Telephone = "0712451111"
            };
            var id = repository.Insert(customer);

            Assert.GreaterOrEqual(id, 1);
        }

        [Test]
        public void Delete_Customer_ReturnDeletedCustomerId()
        {
            var repository = new CustomerRepository(_unitOfWork);

            var customer = new Customer
            {
                Address = "Test address 6",
                CustomerName = "Customer 6",
                CustomerNumber = 6,
                Telephone = "0712451116"
            };
            var id = repository.Insert(customer);
            customer.Id = id;
            var deleteId = repository.Delete(customer);

            Assert.AreEqual(deleteId, id);
        }

        [Test]
        public void Exists_CustomerId_ReturnTrueIfExist()
        {
            var repository = new CustomerRepository(_unitOfWork);
            var isExist = repository.Exists(1);

            Assert.AreEqual(isExist, true);
        }

        [Test]
        public void Exists_CustomerId_ReturnFalseIfNotExist()
        {
            var repository = new CustomerRepository(_unitOfWork);
            var isExist = repository.Exists(10000000);

            Assert.AreEqual(isExist, false);
        }

        [Test]
        public void Update_Customer_ChangeCustomerPropperties()
        {
            var changedName = "Customer name Changed";
            var repository = new CustomerRepository(_unitOfWork);
            var customer = repository.Single(1);
            customer.CustomerName = changedName;
            repository.Update(customer);

            customer = repository.Single(1);

            Assert.AreEqual(customer.CustomerName, changedName);
        }

        [Test]
        public void SingleOrDefault_CustomerId_ReturnCustomerIfExist()
        {
            var repository = new CustomerRepository(_unitOfWork);
            var customer = repository.SingleOrDefault(1);

            Assert.AreEqual(1, customer.Id);
            Assert.AreEqual("Test address 1", customer.Address);
            Assert.IsNotNullOrEmpty(customer.CustomerName);
            Assert.AreEqual(1, customer.CustomerNumber);
            Assert.AreEqual("0712451148", customer.Telephone);
        }

        [Test]
        public void SingleOrDefault_CustomerId_ReturnNullIfNotExist()
        {
            var repository = new CustomerRepository(_unitOfWork);
            var customer = repository.SingleOrDefault(10000);

            Assert.IsNull(customer);
        }
    }
}