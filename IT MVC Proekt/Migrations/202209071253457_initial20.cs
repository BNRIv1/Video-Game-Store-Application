namespace IT_MVC_Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial20 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchasedProducts", "GameId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchasedProducts", "GameId");
        }
    }
}
