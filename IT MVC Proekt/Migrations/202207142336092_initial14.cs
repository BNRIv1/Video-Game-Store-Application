namespace IT_MVC_Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingCarts", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ShoppingCarts", new[] { "User_Id" });
            DropColumn("dbo.ShoppingCarts", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShoppingCarts", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.ShoppingCarts", "User_Id");
            AddForeignKey("dbo.ShoppingCarts", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
