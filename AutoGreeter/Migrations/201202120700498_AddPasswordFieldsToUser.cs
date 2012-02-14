namespace AutoGreeter.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddPasswordFieldsToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("Users", "Salt", c => c.String());
            AddColumn("Users", "PasswordHash", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Users", "PasswordHash");
            DropColumn("Users", "Salt");
        }
    }
}
