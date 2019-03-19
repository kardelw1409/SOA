namespace SudentsService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "test");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "test", c => c.String(nullable: false, maxLength: 2));
        }
    }
}
