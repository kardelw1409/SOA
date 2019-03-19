namespace SudentsService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "test", c => c.String(nullable: false, maxLength: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "test");
        }
    }
}
