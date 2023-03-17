namespace IT_MVC_Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createCartTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "shoppingCart_Id", "dbo.ShoppingCarts");
            DropForeignKey("dbo.AspNetUsers", "cart_Id", "dbo.ShoppingCarts");
            DropIndex("dbo.Games", new[] { "shoppingCart_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "cart_Id" });
            DropColumn("dbo.Games", "shoppingCart_Id");
            DropColumn("dbo.AspNetUsers", "cart_Id");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "cart_Id", c => c.Int());
            AddColumn("dbo.Games", "shoppingCart_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "cart_Id");
            CreateIndex("dbo.Games", "shoppingCart_Id");
            AddForeignKey("dbo.AspNetUsers", "cart_Id", "dbo.ShoppingCarts", "Id");
            AddForeignKey("dbo.Games", "shoppingCart_Id", "dbo.ShoppingCarts", "Id");
        }
    }
}
