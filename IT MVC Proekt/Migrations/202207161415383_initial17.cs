namespace IT_MVC_Proekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial17 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "FeaturedItems_Id", "dbo.FeaturedItems");
            DropIndex("dbo.Games", new[] { "FeaturedItems_Id" });
            DropColumn("dbo.Games", "FeaturedItems_Id");
            DropTable("dbo.FeaturedItems");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FeaturedItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Games", "FeaturedItems_Id", c => c.Int());
            CreateIndex("dbo.Games", "FeaturedItems_Id");
            AddForeignKey("dbo.Games", "FeaturedItems_Id", "dbo.FeaturedItems", "Id");
        }
    }
}
