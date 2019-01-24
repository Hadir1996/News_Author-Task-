namespace NewsAuthorTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updateauthortable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Authors", "LastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Authors", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "Email", c => c.String());
            AlterColumn("dbo.Authors", "LastName", c => c.String());
            AlterColumn("dbo.Authors", "FirstName", c => c.String());
        }
    }
}
