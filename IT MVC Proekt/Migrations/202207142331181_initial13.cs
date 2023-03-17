namespace IT_MVC_Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingCarts", "User_Id", "dbo.AspNetUsers");
            AddForeignKey("dbo.ShoppingCarts", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "User_Id", "dbo.AspNetUsers");
            AddForeignKey("dbo.ShoppingCarts", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
