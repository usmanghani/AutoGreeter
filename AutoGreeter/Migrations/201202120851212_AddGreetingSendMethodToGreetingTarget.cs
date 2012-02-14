namespace AutoGreeter.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddGreetingSendMethodToGreetingTarget : DbMigration
    {
        public override void Up()
        {
            AddColumn("GreetingTargets", "SendMethodValue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("GreetingTargets", "SendMethodValue");
        }
    }
}
