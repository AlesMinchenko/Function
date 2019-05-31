namespace Function.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        A = c.Int(nullable: false),
                        B = c.Int(nullable: false),
                        C = c.Int(nullable: false),
                        Step = c.Single(nullable: false),
                        RangeFrom = c.Int(nullable: false),
                        RangeTo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserDatas");
        }
    }
}
