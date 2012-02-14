namespace AutoGreeter.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGreetingTargetToGreetingRecipient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("GreetingTargets", "Greeting_Id", "Greetings");
            DropForeignKey("GreetingTargets", "UserId", "Users");
            DropForeignKey("GreetingTargets", "Greeting_Id1", "Greetings");
            DropForeignKey("GreetingSchedules", "Target_Id", "GreetingTargets");
            DropForeignKey("GreetingSchedules", "GreetingTarget_Id", "GreetingTargets");
            DropForeignKey("GreetingOccurences", "Target_Id", "GreetingTargets");
            DropIndex("GreetingTargets", new[] { "Greeting_Id" });
            DropIndex("GreetingTargets", new[] { "UserId" });
            DropIndex("GreetingTargets", new[] { "Greeting_Id1" });
            DropIndex("GreetingSchedules", new[] { "Target_Id" });
            DropIndex("GreetingSchedules", new[] { "GreetingTarget_Id" });
            DropIndex("GreetingOccurences", new[] { "Target_Id" });
            CreateTable(
                "GreetingRecipients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TargetAddress = c.String(),
                        SendMethodValue = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Greeting_Id = c.Int(),
                        Greeting_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Greetings", t => t.Greeting_Id)
                .ForeignKey("Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("Greetings", t => t.Greeting_Id1)
                .Index(t => t.Greeting_Id)
                .Index(t => t.UserId)
                .Index(t => t.Greeting_Id1);
            
            AddColumn("GreetingSchedules", "GreetingRecipient_Id", c => c.Int());
            AddForeignKey("GreetingSchedules", "Target_Id", "GreetingRecipients", "Id");
            AddForeignKey("GreetingSchedules", "GreetingRecipient_Id", "GreetingRecipients", "Id");
            AddForeignKey("GreetingOccurences", "Target_Id", "GreetingRecipients", "Id");
            CreateIndex("GreetingSchedules", "Target_Id");
            CreateIndex("GreetingSchedules", "GreetingRecipient_Id");
            CreateIndex("GreetingOccurences", "Target_Id");
            DropColumn("GreetingSchedules", "GreetingTarget_Id");
            DropTable("GreetingTargets");
        }
        
        public override void Down()
        {
            CreateTable(
                "GreetingTargets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TargetAddress = c.String(),
                        SendMethodValue = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Greeting_Id = c.Int(),
                        Greeting_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("GreetingSchedules", "GreetingTarget_Id", c => c.Int());
            DropIndex("GreetingOccurences", new[] { "Target_Id" });
            DropIndex("GreetingSchedules", new[] { "GreetingRecipient_Id" });
            DropIndex("GreetingSchedules", new[] { "Target_Id" });
            DropIndex("GreetingRecipients", new[] { "Greeting_Id1" });
            DropIndex("GreetingRecipients", new[] { "UserId" });
            DropIndex("GreetingRecipients", new[] { "Greeting_Id" });
            DropForeignKey("GreetingOccurences", "Target_Id", "GreetingRecipients");
            DropForeignKey("GreetingSchedules", "GreetingRecipient_Id", "GreetingRecipients");
            DropForeignKey("GreetingSchedules", "Target_Id", "GreetingRecipients");
            DropForeignKey("GreetingRecipients", "Greeting_Id1", "Greetings");
            DropForeignKey("GreetingRecipients", "UserId", "Users");
            DropForeignKey("GreetingRecipients", "Greeting_Id", "Greetings");
            DropColumn("GreetingSchedules", "GreetingRecipient_Id");
            DropTable("GreetingRecipients");
            CreateIndex("GreetingOccurences", "Target_Id");
            CreateIndex("GreetingSchedules", "GreetingTarget_Id");
            CreateIndex("GreetingSchedules", "Target_Id");
            CreateIndex("GreetingTargets", "Greeting_Id1");
            CreateIndex("GreetingTargets", "UserId");
            CreateIndex("GreetingTargets", "Greeting_Id");
            AddForeignKey("GreetingOccurences", "Target_Id", "GreetingTargets", "Id");
            AddForeignKey("GreetingSchedules", "GreetingTarget_Id", "GreetingTargets", "Id");
            AddForeignKey("GreetingSchedules", "Target_Id", "GreetingTargets", "Id");
            AddForeignKey("GreetingTargets", "Greeting_Id1", "Greetings", "Id");
            AddForeignKey("GreetingTargets", "UserId", "Users", "Id", cascadeDelete: true);
            AddForeignKey("GreetingTargets", "Greeting_Id", "Greetings", "Id");
        }
    }
}
