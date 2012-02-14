namespace AutoGreeter.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddUserSession : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "UserSessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Token = c.String(),
                        UserId = c.Int(nullable: false),
                        Username = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        LastLoginTimestamp = c.DateTime(nullable: false),
                        ExpirationTimestamp = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("UserSessions", new[] { "UserId" });
            DropForeignKey("UserSessions", "UserId", "Users");
            DropTable("UserSessions");
        }
    }
}
