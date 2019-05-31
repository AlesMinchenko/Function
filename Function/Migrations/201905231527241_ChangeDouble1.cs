namespace Function.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDouble1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserDatas", "Step", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserDatas", "Step", c => c.Single(nullable: false));
        }
    }
}
