namespace E02_EF6_Migrations_Books_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M03Book_New_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeweyDecimalClassification",
                c => new
                    {
                        DeweyID = c.Int(nullable: false, identity: true),
                        DdcCode = c.String(),
                        DDC = c.String(),
                    })
                .PrimaryKey(t => t.DeweyID);
            
            AddColumn("dbo.Book", "DdcID", c => c.Int(nullable: false));
            AddColumn("dbo.Book", "Ddc_DeweyID", c => c.Int());
            CreateIndex("dbo.Book", "Ddc_DeweyID");
            AddForeignKey("dbo.Book", "Ddc_DeweyID", "dbo.DeweyDecimalClassification", "DeweyID");
            DropColumn("dbo.Book", "DDC");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Book", "DDC", c => c.String(nullable: false, maxLength: 100));
            DropForeignKey("dbo.Book", "Ddc_DeweyID", "dbo.DeweyDecimalClassification");
            DropIndex("dbo.Book", new[] { "Ddc_DeweyID" });
            DropColumn("dbo.Book", "Ddc_DeweyID");
            DropColumn("dbo.Book", "DdcID");
            DropTable("dbo.DeweyDecimalClassification");
        }
    }
}
