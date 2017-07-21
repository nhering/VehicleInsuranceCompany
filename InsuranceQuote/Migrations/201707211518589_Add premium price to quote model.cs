namespace InsuranceQuote.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addpremiumpricetoquotemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuoteModels", "AnnualPremium", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuoteModels", "AnnualPremium");
        }
    }
}
