namespace Lab_33_MVC_Framework_Entity_Helpdesk.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewField2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "NewField2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "NewField2");
        }
    }
}
