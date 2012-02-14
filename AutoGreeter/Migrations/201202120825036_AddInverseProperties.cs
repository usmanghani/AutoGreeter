namespace AutoGreeter.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddInverseProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("GreetingTargets", "GreetingId", "Greetings");
            DropForeignKey("GreetingSchedules", "GreetingId", "Greetings");
            DropForeignKey("GreetingSchedules", "GreetingTargetId", "GreetingTargets");
            DropForeignKey("GreetingOccurences", "GreetingId", "Greetings");
            DropForeignKey("GreetingOccurences", "GreetingTargetId", "GreetingTargets");
            DropForeignKey("GreetingOccurences", "GreetingScheduleId", "GreetingSchedules");
            DropIndex("GreetingTargets", new[] { "GreetingId" });
            DropIndex("GreetingSchedules", new[] { "GreetingId" });
            DropIndex("GreetingSchedules", new[] { "GreetingTargetId" });
            DropIndex("GreetingOccurences", new[] { "GreetingId" });
            DropIndex("GreetingOccurences", new[] { "GreetingTargetId" });
            DropIndex("GreetingOccurences", new[] { "GreetingScheduleId" });
            RenameColumn(table: "GreetingTargets", name: "GreetingId", newName: "Greeting_Id");
            RenameColumn(table: "GreetingSchedules", name: "GreetingId", newName: "Greeting_Id");
            RenameColumn(table: "GreetingSchedules", name: "GreetingTargetId", newName: "Target_Id");
            RenameColumn(table: "GreetingOccurences", name: "GreetingId", newName: "Greeting_Id");
            RenameColumn(table: "GreetingOccurences", name: "GreetingTargetId", newName: "Target_Id");
            RenameColumn(table: "GreetingOccurences", name: "GreetingScheduleId", newName: "Schedule_Id");
            AddColumn("GreetingTargets", "Greeting_Id1", c => c.Int());
            AddColumn("GreetingSchedules", "GreetingTarget_Id", c => c.Int());
            AddColumn("GreetingOccurences", "GreetingSchedule_Id", c => c.Int());
            AddForeignKey("GreetingTargets", "Greeting_Id", "Greetings", "Id");
            AddForeignKey("GreetingTargets", "Greeting_Id1", "Greetings", "Id");
            AddForeignKey("GreetingSchedules", "Greeting_Id", "Greetings", "Id");
            AddForeignKey("GreetingSchedules", "Target_Id", "GreetingTargets", "Id");
            AddForeignKey("GreetingSchedules", "GreetingTarget_Id", "GreetingTargets", "Id");
            AddForeignKey("GreetingOccurences", "Greeting_Id", "Greetings", "Id");
            AddForeignKey("GreetingOccurences", "Target_Id", "GreetingTargets", "Id");
            AddForeignKey("GreetingOccurences", "Schedule_Id", "GreetingSchedules", "Id");
            AddForeignKey("GreetingOccurences", "GreetingSchedule_Id", "GreetingSchedules", "Id");
            CreateIndex("GreetingTargets", "Greeting_Id");
            CreateIndex("GreetingTargets", "Greeting_Id1");
            CreateIndex("GreetingSchedules", "Greeting_Id");
            CreateIndex("GreetingSchedules", "Target_Id");
            CreateIndex("GreetingSchedules", "GreetingTarget_Id");
            CreateIndex("GreetingOccurences", "Greeting_Id");
            CreateIndex("GreetingOccurences", "Target_Id");
            CreateIndex("GreetingOccurences", "Schedule_Id");
            CreateIndex("GreetingOccurences", "GreetingSchedule_Id");
        }
        
        public override void Down()
        {
            DropIndex("GreetingOccurences", new[] { "GreetingSchedule_Id" });
            DropIndex("GreetingOccurences", new[] { "Schedule_Id" });
            DropIndex("GreetingOccurences", new[] { "Target_Id" });
            DropIndex("GreetingOccurences", new[] { "Greeting_Id" });
            DropIndex("GreetingSchedules", new[] { "GreetingTarget_Id" });
            DropIndex("GreetingSchedules", new[] { "Target_Id" });
            DropIndex("GreetingSchedules", new[] { "Greeting_Id" });
            DropIndex("GreetingTargets", new[] { "Greeting_Id1" });
            DropIndex("GreetingTargets", new[] { "Greeting_Id" });
            DropForeignKey("GreetingOccurences", "GreetingSchedule_Id", "GreetingSchedules");
            DropForeignKey("GreetingOccurences", "Schedule_Id", "GreetingSchedules");
            DropForeignKey("GreetingOccurences", "Target_Id", "GreetingTargets");
            DropForeignKey("GreetingOccurences", "Greeting_Id", "Greetings");
            DropForeignKey("GreetingSchedules", "GreetingTarget_Id", "GreetingTargets");
            DropForeignKey("GreetingSchedules", "Target_Id", "GreetingTargets");
            DropForeignKey("GreetingSchedules", "Greeting_Id", "Greetings");
            DropForeignKey("GreetingTargets", "Greeting_Id1", "Greetings");
            DropForeignKey("GreetingTargets", "Greeting_Id", "Greetings");
            DropColumn("GreetingOccurences", "GreetingSchedule_Id");
            DropColumn("GreetingSchedules", "GreetingTarget_Id");
            DropColumn("GreetingTargets", "Greeting_Id1");
            RenameColumn(table: "GreetingOccurences", name: "Schedule_Id", newName: "GreetingScheduleId");
            RenameColumn(table: "GreetingOccurences", name: "Target_Id", newName: "GreetingTargetId");
            RenameColumn(table: "GreetingOccurences", name: "Greeting_Id", newName: "GreetingId");
            RenameColumn(table: "GreetingSchedules", name: "Target_Id", newName: "GreetingTargetId");
            RenameColumn(table: "GreetingSchedules", name: "Greeting_Id", newName: "GreetingId");
            RenameColumn(table: "GreetingTargets", name: "Greeting_Id", newName: "GreetingId");
            CreateIndex("GreetingOccurences", "GreetingScheduleId");
            CreateIndex("GreetingOccurences", "GreetingTargetId");
            CreateIndex("GreetingOccurences", "GreetingId");
            CreateIndex("GreetingSchedules", "GreetingTargetId");
            CreateIndex("GreetingSchedules", "GreetingId");
            CreateIndex("GreetingTargets", "GreetingId");
            AddForeignKey("GreetingOccurences", "GreetingScheduleId", "GreetingSchedules", "Id");
            AddForeignKey("GreetingOccurences", "GreetingTargetId", "GreetingTargets", "Id");
            AddForeignKey("GreetingOccurences", "GreetingId", "Greetings", "Id");
            AddForeignKey("GreetingSchedules", "GreetingTargetId", "GreetingTargets", "Id");
            AddForeignKey("GreetingSchedules", "GreetingId", "Greetings", "Id");
            AddForeignKey("GreetingTargets", "GreetingId", "Greetings", "Id");
        }
    }
}
