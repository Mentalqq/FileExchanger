namespace FinalTaskTry5.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ExceptionLoggers", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.ExceptionLoggers", "ApplicationUser_Id");
            AddForeignKey("dbo.ExceptionLoggers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExceptionLoggers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ExceptionLoggers", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.ExceptionLoggers", "ApplicationUser_Id");
        }
    }
}
