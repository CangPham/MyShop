namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedatetimeuser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "BirthDay");
            DropColumn("dbo.AspNetUsers", "RegisterDate");
            DropColumn("dbo.AspNetUsers", "BanedDate");
            DropColumn("dbo.AspNetUsers", "LastLoginDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "LastLoginDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "BanedDate", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "RegisterDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "BirthDay", c => c.DateTime());
        }
    }
}
