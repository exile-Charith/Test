using System.Data.Entity.Migrations;

namespace FoveaExampleRepository.Migrations
{
    public partial class FoveaDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                {
                    Id = c.Int(false, true),
                    CustomerNumber = c.Int(false),
                    CustomerName = c.String(),
                    Telephone = c.String(),
                    Address = c.String()
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Files",
                c => new
                {
                    Id = c.Int(false, true),
                    Week = c.String(),
                    Sequence = c.Int(false),
                    Weight = c.Double(false),
                    Customer_Id = c.Int()
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);

            CreateTable(
                "dbo.Departments",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(),
                    MyProperty = c.Int(false)
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Files", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Files", new[] {"Customer_Id"});
            DropTable("dbo.Departments");
            DropTable("dbo.Files");
            DropTable("dbo.Customers");
        }
    }
}