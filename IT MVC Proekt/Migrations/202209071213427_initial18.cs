namespace IT_MVC_Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial18 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchasedProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Name = c.String(),
                        ImageURL = c.String(),
                        Description = c.String(),
                        Genre = c.String(),
                        Developer = c.String(),
                        Date = c.String(),
                        Price = c.Double(nullable: false),
                        LongDesc = c.String(),
                        DescImg = c.String(),
                        Screenshot1 = c.String(),
                        Screenshot2 = c.String(),
                        Screenshot3 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PurchasedProducts");
        }
    }
}
