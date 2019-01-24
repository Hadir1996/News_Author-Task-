namespace NewsAuthorTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletelastnameinauthor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "Name", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Authors", "FirstName");
            DropColumn("dbo.Authors", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "LastName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Authors", "FirstName", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Authors", "Name");
        }
    }
}
