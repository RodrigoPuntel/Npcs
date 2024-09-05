namespace Npcs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alt1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CategoryDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskName = c.String(),
                        TaskDescription = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        ConclusionDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CategoryId);
            
            AddColumn("dbo.Users", "EmailAdress", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "UserId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Tasks", new[] { "CategoryId" });
            DropIndex("dbo.Tasks", new[] { "UserId" });
            DropColumn("dbo.Users", "EmailAdress");
            DropTable("dbo.Tasks");
            DropTable("dbo.Categories");
        }
    }
}
