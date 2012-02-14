namespace AutoGreeter.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCommentsFromCode : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("GreetingSchedules", "Target_Id", "GreetingRecipients");
            DropForeignKey("GreetingOccurences", "Target_Id", "GreetingRecipients");
            DropIndex("GreetingSchedules", new[] { "Target_Id" });
            DropIndex("GreetingOccurences", new[] { "Target_Id" });
            AddColumn("GreetingSchedules", "Recipient_Id", c => c.Int());
            AddColumn("GreetingOccurences", "Recipient_Id", c => c.Int());
            AlterColumn("UserSessions", "CreatedAt", c => c.DateTime(nullable: false));
            AddForeignKey("GreetingSchedules", "Recipient_Id", "GreetingRecipients", "Id");
            AddForeignKey("GreetingOccurences", "Recipient_Id", "GreetingRecipients", "Id");
            CreateIndex("GreetingSchedules", "Recipient_Id");
            CreateIndex("GreetingOccurences", "Recipient_Id");
            DropColumn("GreetingSchedules", "Target_Id");
            DropColumn("GreetingOccurences", "Target_Id");
        }
        
        public override void Down()
        {
            AddColumn("GreetingOccurences", "Target_Id", c => c.Int());
            AddColumn("GreetingSchedules", "Target_Id", c => c.Int());
            DropIndex("GreetingOccurences", new[] { "Recipient_Id" });
            DropIndex("GreetingSchedules", new[] { "Recipient_Id" });
            DropForeignKey("GreetingOccurences", "Recipient_Id", "GreetingRecipients");
            DropForeignKey("GreetingSchedules", "Recipient_Id", "GreetingRecipients");
            AlterColumn("UserSessions", "CreatedAt", c => c.DateTime(nullable: false));
            DropColumn("GreetingOccurences", "Recipient_Id");
            DropColumn("GreetingSchedules", "Recipient_Id");
            CreateIndex("GreetingOccurences", "Target_Id");
            CreateIndex("GreetingSchedules", "Target_Id");
            AddForeignKey("GreetingOccurences", "Target_Id", "GreetingRecipients", "Id");
            AddForeignKey("GreetingSchedules", "Target_Id", "GreetingRecipients", "Id");
        }
    }
}
