namespace IT_MVC_Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial15 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeaturedItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        game_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.game_Id)
                .Index(t => t.game_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeaturedItems", "game_Id", "dbo.Games");
            DropIndex("dbo.FeaturedItems", new[] { "game_Id" });
            DropTable("dbo.FeaturedItems");
        }
    }
}
