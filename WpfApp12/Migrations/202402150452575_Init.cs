namespace WpfApp12.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Brand", c => c.String());
            AlterColumn("dbo.Cars", "Condition", c => c.String());
            AlterColumn("dbo.Cars", "Category", c => c.String());
            AlterColumn("dbo.Cars", "Color", c => c.String());
            AlterColumn("dbo.Cars", "FuelType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cars", "FuelType", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "Color", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "Category", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "Condition", c => c.Int(nullable: false));
            AlterColumn("dbo.Cars", "Brand", c => c.Int(nullable: false));
        }
    }
}
