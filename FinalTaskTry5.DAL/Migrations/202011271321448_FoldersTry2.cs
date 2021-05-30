namespace FinalTaskTry5.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class FoldersTry2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Folders", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Folders", "User_Id");
            AddForeignKey("dbo.Folders", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Folders", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Folders", new[] { "User_Id" });
            DropColumn("dbo.Folders", "User_Id");
        }
    }
}
