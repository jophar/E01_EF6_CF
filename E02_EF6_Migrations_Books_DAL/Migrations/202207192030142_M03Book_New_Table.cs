namespace E02_EF6_Migrations_Books_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M03Book_New_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        PublisherID = c.Int(nullable: false),
                        DeweyID = c.Int(nullable: false),
                        ISBN = c.String(nullable: false, maxLength: 9),
                        Titulo = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.BookID)
                .ForeignKey("dbo.DeweyDecimalClassification", t => t.DeweyID, cascadeDelete: true)
                .ForeignKey("dbo.Publisher", t => t.PublisherID, cascadeDelete: true)
                .Index(t => t.DeweyID)
                .Index(t => t.PublisherID);
            
            CreateTable(
                "dbo.DeweyDecimalClassification",
                c => new
                    {
                        DeweyID = c.Int(nullable: false, identity: true),
                        DdcCode = c.String(),
                        DDC = c.String(),
                    })
                .PrimaryKey(t => t.DeweyID);
            
            CreateTable(
                "dbo.Publisher",
                c => new
                    {
                        PublisherID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.PublisherID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "PublisherID", "dbo.Publisher");
            DropForeignKey("dbo.Book", "DeweyID", "dbo.DeweyDecimalClassification");
            DropIndex("dbo.Book", new[] { "PublisherID" });
            DropIndex("dbo.Book", new[] { "DeweyID" });
            DropTable("dbo.Publisher");
            DropTable("dbo.DeweyDecimalClassification");
            DropTable("dbo.Book");
        }
    }
}
