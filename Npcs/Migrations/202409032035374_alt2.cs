namespace Npcs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alt2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "Status");
        }
    }
}
