namespace FinalTaskTry5.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrashAndRequests : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.Files", "Trash", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Requests", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Files", "Trash");
            DropTable("dbo.Requests");
        }
    }
}
