namespace AutoGreeter.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDatabaseGeneratedAttributes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Users", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("Users", "UpdatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("Users", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("Users", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
