namespace Vid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMembershipName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name='PayAsYouGo' WHERE Id=1 ");
            Sql("UPDATE MembershipTypes SET Name='Montly' WHERE Id=2 ");
            Sql("UPDATE MembershipTypes SET Name='Quarterly' WHERE Id=3 ");
            Sql("UPDATE MembershipTypes SET Name='Annual' WHERE Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
