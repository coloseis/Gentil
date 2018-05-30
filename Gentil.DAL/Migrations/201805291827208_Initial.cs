namespace Gentil.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Policy",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        AmountInsured = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Email = c.String(),
                        InceptionDate = c.DateTime(nullable: false),
                        InstallmentPayment = c.Boolean(nullable: false),
                        ClientId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Policy");
            DropTable("dbo.Client");
        }
    }
}
