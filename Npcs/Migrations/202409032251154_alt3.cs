namespace Npcs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alt3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tasks", "ConclusionDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tasks", "ConclusionDate", c => c.DateTime(nullable: false));
        }
    }
}
