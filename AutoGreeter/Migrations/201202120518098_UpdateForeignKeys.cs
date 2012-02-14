namespace AutoGreeter.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateForeignKeys : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("Greetings", "UserId", "Users");

            AddForeignKey("GreetingTargets", "UserId", "Users");

            AddForeignKey("GreetingSchedules", "UserId", "Users");
            AddForeignKey("GreetingSchedules", "GreetingId", "Greetings");

            AddForeignKey("GreetingOccurences", "UserId", "Users");
            AddForeignKey("GreetingOccurences", "GreetingId", "Greetings");
            AddForeignKey("GreetingOccurences", "GreetingTargetId", "GreetingTargets");
        }

        public override void Down()
        {
            DropForeignKey("Greetings", "UserId", "Users");

            DropForeignKey("GreetingTargets", "UserId", "Users");

            DropForeignKey("GreetingSchedules", "UserId", "Users");
            DropForeignKey("GreetingSchedules", "GreetingId", "Greetings");

            DropForeignKey("GreetingOccurences", "UserId", "Users");
            DropForeignKey("GreetingOccurences", "GreetingId", "Greetings");
            DropForeignKey("GreetingOccurences", "GreetingTargetId", "GreetingTargets");

        }
    }
}
