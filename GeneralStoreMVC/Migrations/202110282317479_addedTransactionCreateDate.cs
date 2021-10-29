namespace GeneralStoreMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedTransactionCreateDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "CreatedAt");
        }
    }
}
