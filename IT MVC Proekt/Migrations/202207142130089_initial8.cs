namespace IT_MVC_Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Games", "ShoppingCart_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "cart_Id", c => c.Int());
            CreateIndex("dbo.Games", "ShoppingCart_Id");
            CreateIndex("dbo.AspNetUsers", "cart_Id");
            AddForeignKey("dbo.Games", "ShoppingCart_Id", "dbo.ShoppingCarts", "Id");
            AddForeignKey("dbo.AspNetUsers", "cart_Id", "dbo.ShoppingCarts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "cart_Id", "dbo.ShoppingCarts");
            DropForeignKey("dbo.Games", "ShoppingCart_Id", "dbo.ShoppingCarts");
            DropIndex("dbo.AspNetUsers", new[] { "cart_Id" });
            DropIndex("dbo.Games", new[] { "ShoppingCart_Id" });
            DropColumn("dbo.AspNetUsers", "cart_Id");
            DropColumn("dbo.Games", "ShoppingCart_Id");
            DropTable("dbo.ShoppingCarts");
        }
    }
}
