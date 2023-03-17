namespace IT_MVC_Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial9 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Games", new[] { "ShoppingCart_Id" });
            CreateIndex("dbo.Games", "shoppingCart_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Games", new[] { "shoppingCart_Id" });
            CreateIndex("dbo.Games", "ShoppingCart_Id");
        }
    }
}
