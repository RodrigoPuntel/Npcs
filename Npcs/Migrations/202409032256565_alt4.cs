namespace Npcs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alt4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Tasks", new[] { "CategoryId" });
            AlterColumn("dbo.Tasks", "CategoryId", c => c.Int());
            CreateIndex("dbo.Tasks", "CategoryId");
            AddForeignKey("dbo.Tasks", "CategoryId", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Tasks", new[] { "CategoryId" });
            AlterColumn("dbo.Tasks", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tasks", "CategoryId");
            AddForeignKey("dbo.Tasks", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
