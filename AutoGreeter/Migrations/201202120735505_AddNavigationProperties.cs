namespace AutoGreeter.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddNavigationProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Users", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("Users", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("Greetings", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("Greetings", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingTargets", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingTargets", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingSchedules", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingSchedules", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingOccurences", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingOccurences", "UpdatedAt", c => c.DateTime(nullable: false));
            AddForeignKey("GreetingSchedules", "GreetingId", "Greetings", "Id");
            AddForeignKey("GreetingOccurences", "GreetingId", "Greetings", "Id");
            AddForeignKey("GreetingOccurences", "GreetingTargetId", "GreetingTargets", "Id");
            CreateIndex("GreetingSchedules", "GreetingId");
            CreateIndex("GreetingOccurences", "GreetingId");
            CreateIndex("GreetingOccurences", "GreetingTargetId");
        }
        
        public override void Down()
        {
            DropIndex("GreetingOccurences", new[] { "GreetingTargetId" });
            DropIndex("GreetingOccurences", new[] { "GreetingId" });
            DropIndex("GreetingSchedules", new[] { "GreetingId" });
            DropForeignKey("GreetingOccurences", "GreetingTargetId", "GreetingTargets");
            DropForeignKey("GreetingOccurences", "GreetingId", "Greetings");
            DropForeignKey("GreetingSchedules", "GreetingId", "Greetings");
            AlterColumn("GreetingOccurences", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingOccurences", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingSchedules", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingSchedules", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingTargets", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("GreetingTargets", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("Greetings", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("Greetings", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("Users", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("Users", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
