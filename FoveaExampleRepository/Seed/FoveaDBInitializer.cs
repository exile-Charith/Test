using System.Collections.Generic;
using System.Data.Entity;
using FoveaExampleRepository.Entities;

namespace FoveaExampleRepository.Seed
{
    public class FoveaDbInitializer : CreateDatabaseIfNotExists<FoveaContext>
    {
        protected override void Seed(FoveaContext context)
        {
            IList<Customer> defaultCustomer = new List<Customer>();

            defaultCustomer.Add(new Customer
            {
                Address = "Test address 1",
                CustomerName = "Customer 1",
                CustomerNumber = 1,
                Telephone = "0712451148"
            });
            defaultCustomer.Add(new Customer
            {
                Address = "Test address 2",
                CustomerName = "Customer 2",
                CustomerNumber = 2,
                Telephone = "0712451149"
            });
            defaultCustomer.Add(new Customer
            {
                Address = "Test address 3",
                CustomerName = "Customer 3",
                CustomerNumber = 3,
                Telephone = "0712451110"
            });

            foreach (var cst in defaultCustomer)
                context.Customers.Add(cst);

            base.Seed(context);
        }
    }
}