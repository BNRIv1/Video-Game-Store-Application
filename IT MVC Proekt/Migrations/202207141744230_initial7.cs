namespace IT_MVC_Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "ShoppingCart_Id", "dbo.ShoppingCarts");
            DropForeignKey("dbo.AspNetUsers", "cart_Id", "dbo.ShoppingCarts");
            DropIndex("dbo.Games", new[] { "ShoppingCart_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "cart_Id" });
            DropColumn("dbo.Games", "ShoppingCart_Id");
            DropColumn("dbo.AspNetUsers", "cart_Id");
            DropTable("dbo.ShoppingCarts");
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
            AddColumn("dbo.Games", "ShoppingCart_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "cart_Id");
            CreateIndex("dbo.Games", "ShoppingCart_Id");
            AddForeignKey("dbo.AspNetUsers", "cart_Id", "dbo.ShoppingCarts", "Id");
            AddForeignKey("dbo.Games", "ShoppingCart_Id", "dbo.ShoppingCarts", "Id");
        }
    }
}
