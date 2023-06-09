﻿namespace IT_MVC_Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial10 : DbMigration
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
            CreateIndex("dbo.Games", "ShoppingCart_Id");
            AddForeignKey("dbo.Games", "ShoppingCart_Id", "dbo.ShoppingCarts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "ShoppingCart_Id", "dbo.ShoppingCarts");
            DropIndex("dbo.Games", new[] { "ShoppingCart_Id" });
            DropColumn("dbo.Games", "ShoppingCart_Id");
            DropTable("dbo.ShoppingCarts");
        }
    }
}
