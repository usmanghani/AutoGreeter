namespace AutoGreeter.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        Username = c.String(),
                        Email = c.String(),
                        TwitterHandle = c.String(),
                        FacebookHandle = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "Greetings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GreetingText = c.String(),
                        UserId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "GreetingTargets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GreetingId = c.Int(nullable: false),
                        TargetAddress = c.String(),
                        UserId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Greetings", t => t.GreetingId, cascadeDelete: true)
                .Index(t => t.GreetingId);

            CreateTable(
                "GreetingSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        GreetingId = c.Int(nullable: false),
                        GreetingTargetId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("GreetingTargets", t => t.GreetingTargetId, cascadeDelete: true)
                .Index(t => t.GreetingTargetId);

            CreateTable(
                "GreetingOccurences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GreetingId = c.Int(nullable: false),
                        GreetingTargetId = c.Int(nullable: false),
                        GreetingScheduleId = c.Int(nullable: false),
                        StartAt = c.DateTime(nullable: false),
                        EndAt = c.DateTime(nullable: false),
                        RepeatCount = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("GreetingSchedules", t => t.GreetingScheduleId, cascadeDelete: true)
                .Index(t => t.GreetingScheduleId);
        }

        public override void Down()
        {
            DropIndex("GreetingOccurences", new[] { "GreetingScheduleId" });
            DropIndex("GreetingSchedules", new[] { "GreetingTargetId" });
            DropIndex("GreetingTargets", new[] { "GreetingId" });
            DropForeignKey("GreetingOccurences", "GreetingScheduleId", "GreetingSchedules");
            DropForeignKey("GreetingSchedules", "GreetingTargetId", "GreetingTargets");
            DropForeignKey("GreetingTargets", "GreetingId", "Greetings");
            DropTable("GreetingOccurences");
            DropTable("GreetingSchedules");
            DropTable("GreetingTargets");
            DropTable("Greetings");
            DropTable("Users");
        }
    }
}
