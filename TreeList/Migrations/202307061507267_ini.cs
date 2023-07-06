namespace TreeList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TreeItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ParentID = c.Int(),
                        NodeData = c.String(),
                        TreeItem_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TreeItems", t => t.TreeItem_ID)
                .Index(t => t.TreeItem_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TreeItems", "TreeItem_ID", "dbo.TreeItems");
            DropIndex("dbo.TreeItems", new[] { "TreeItem_ID" });
            DropTable("dbo.TreeItems");
        }
    }
}
