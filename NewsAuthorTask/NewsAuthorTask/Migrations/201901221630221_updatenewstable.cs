namespace NewsAuthorTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatenewstable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "newstitle", c => c.String(nullable: false));
            AlterColumn("dbo.News", "newscontent", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "newscontent", c => c.String());
            AlterColumn("dbo.News", "newstitle", c => c.String());
        }
    }
}
