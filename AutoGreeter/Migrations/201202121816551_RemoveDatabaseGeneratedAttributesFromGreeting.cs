namespace AutoGreeter.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDatabaseGeneratedAttributesFromGreeting : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Greetings", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("Greetings", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingTargets", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingTargets", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingSchedules", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingSchedules", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingOccurences", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingOccurences", "UpdatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("GreetingOccurences", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingOccurences", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingSchedules", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingSchedules", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingTargets", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingTargets", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("Greetings", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("Greetings", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
