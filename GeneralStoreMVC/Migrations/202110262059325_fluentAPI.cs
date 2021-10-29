namespace GeneralStoreMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fluentAPI : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Transaction_TransactionID", "dbo.Transactions");
            DropIndex("dbo.Products", new[] { "Transaction_TransactionID" });
            CreateTable(
                "dbo.TransactionProducts",
                c => new
                    {
                        Transaction_TransactionID = c.Int(nullable: false),
                        Product_ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Transaction_TransactionID, t.Product_ProductID })
                .ForeignKey("dbo.Transactions", t => t.Transaction_TransactionID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductID, cascadeDelete: true)
                .Index(t => t.Transaction_TransactionID)
                .Index(t => t.Product_ProductID);
            
            DropColumn("dbo.Products", "Transaction_TransactionID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Transaction_TransactionID", c => c.Int());
            DropForeignKey("dbo.TransactionProducts", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.TransactionProducts", "Transaction_TransactionID", "dbo.Transactions");
            DropIndex("dbo.TransactionProducts", new[] { "Product_ProductID" });
            DropIndex("dbo.TransactionProducts", new[] { "Transaction_TransactionID" });
            DropTable("dbo.TransactionProducts");
            CreateIndex("dbo.Products", "Transaction_TransactionID");
            AddForeignKey("dbo.Products", "Transaction_TransactionID", "dbo.Transactions", "TransactionID");
        }
    }
}
