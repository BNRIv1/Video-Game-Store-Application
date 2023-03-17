namespace IT_MVC_Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial19 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "ShoppingCart_Id", "dbo.ShoppingCarts");
            DropIndex("dbo.Games", new[] { "ShoppingCart_Id" });
            DropColumn("dbo.Games", "ShoppingCart_Id");
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
            
            AddColumn("dbo.Games", "ShoppingCart_Id", c => c.Int());
            CreateIndex("dbo.Games", "ShoppingCart_Id");
            AddForeignKey("dbo.Games", "ShoppingCart_Id", "dbo.ShoppingCarts", "Id");
        }
    }
}
