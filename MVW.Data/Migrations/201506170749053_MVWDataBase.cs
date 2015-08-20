namespace MVW.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MVWDataBase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Word", "CreateUser", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Word", "CreateUser");
        }
    }
}
