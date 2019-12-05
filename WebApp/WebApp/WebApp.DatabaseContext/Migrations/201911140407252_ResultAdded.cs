namespace WebApp.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResultAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResultDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Marks = c.Int(nullable: false),
                        ResultId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Results", t => t.ResultId, cascadeDelete: true)
                .Index(t => t.ResultId);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResultDetails", "ResultId", "dbo.Results");
            DropIndex("dbo.ResultDetails", new[] { "ResultId" });
            DropTable("dbo.Results");
            DropTable("dbo.ResultDetails");
        }
    }
}
