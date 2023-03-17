namespace IT_MVC_Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial16 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FeaturedItems", "game_Id", "dbo.Games");
            DropIndex("dbo.FeaturedItems", new[] { "game_Id" });
            AddColumn("dbo.Games", "FeaturedItems_Id", c => c.Int());
            CreateIndex("dbo.Games", "FeaturedItems_Id");
            AddForeignKey("dbo.Games", "FeaturedItems_Id", "dbo.FeaturedItems", "Id");
            DropColumn("dbo.FeaturedItems", "game_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FeaturedItems", "game_Id", c => c.Int());
            DropForeignKey("dbo.Games", "FeaturedItems_Id", "dbo.FeaturedItems");
            DropIndex("dbo.Games", new[] { "FeaturedItems_Id" });
            DropColumn("dbo.Games", "FeaturedItems_Id");
            CreateIndex("dbo.FeaturedItems", "game_Id");
            AddForeignKey("dbo.FeaturedItems", "game_Id", "dbo.Games", "Id");
        }
    }
}
