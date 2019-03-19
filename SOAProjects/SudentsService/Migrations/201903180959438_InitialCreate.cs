namespace SudentsService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        RegId = c.Int(nullable: false, identity: true),
                        Course = c.Int(nullable: false),
                        Enrolled = c.DateTime(nullable: false),
                        GroupID = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RegId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
