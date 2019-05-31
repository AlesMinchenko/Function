namespace Function.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserDatas", "Step", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserDatas", "Step", c => c.Double(nullable: false));
        }
    }
}
