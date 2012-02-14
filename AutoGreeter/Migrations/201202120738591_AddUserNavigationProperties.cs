namespace AutoGreeter.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddUserNavigationProperties : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("Greetings", "UserId", "Users", "Id");
            AddForeignKey("GreetingTargets", "UserId", "Users", "Id");
            AddForeignKey("GreetingSchedules", "UserId", "Users", "Id");
            AddForeignKey("GreetingOccurences", "UserId", "Users", "Id");
            CreateIndex("Greetings", "UserId");
            CreateIndex("GreetingTargets", "UserId");
            CreateIndex("GreetingSchedules", "UserId");
            CreateIndex("GreetingOccurences", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("GreetingOccurences", new[] { "UserId" });
            DropIndex("GreetingSchedules", new[] { "UserId" });
            DropIndex("GreetingTargets", new[] { "UserId" });
            DropIndex("Greetings", new[] { "UserId" });
            DropForeignKey("GreetingOccurences", "UserId", "Users");
            DropForeignKey("GreetingSchedules", "UserId", "Users");
            DropForeignKey("GreetingTargets", "UserId", "Users");
            DropForeignKey("Greetings", "UserId", "Users");
        }
    }
}
