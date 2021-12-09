namespace web_app_asp_net_mvc_html.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "ImageTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ImageTitle", c => c.String());
        }
    }
}
