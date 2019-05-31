namespace Function.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBuilder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Charts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserData_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserDatas", t => t.UserData_Id)
                .Index(t => t.UserData_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Charts", "UserData_Id", "dbo.UserDatas");
            DropIndex("dbo.Charts", new[] { "UserData_Id" });
            DropTable("dbo.Charts");
        }
    }
}
