namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class writerupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "AboutWriter", c => c.String(maxLength: 150));
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 200));
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 6));
            AlterColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 30));
            DropColumn("dbo.Writers", "AboutWriter");
        }
    }
}
