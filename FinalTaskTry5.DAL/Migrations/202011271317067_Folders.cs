namespace FinalTaskTry5.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Folders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Folders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Files", "Folder_Id", c => c.Int());
            CreateIndex("dbo.Files", "Folder_Id");
            AddForeignKey("dbo.Files", "Folder_Id", "dbo.Folders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "Folder_Id", "dbo.Folders");
            DropIndex("dbo.Files", new[] { "Folder_Id" });
            DropColumn("dbo.Files", "Folder_Id");
            DropTable("dbo.Folders");
        }
    }
}
