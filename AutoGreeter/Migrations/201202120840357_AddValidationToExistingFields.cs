namespace AutoGreeter.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddValidationToExistingFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Users", "Username", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("Users", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("Users", "Email", c => c.String());
            AlterColumn("Users", "Username", c => c.String());
        }
    }
}
