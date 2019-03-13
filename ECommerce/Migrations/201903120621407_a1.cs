namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Products", "ProducerId");
            AddForeignKey("dbo.Products", "ProducerId", "dbo.Producers", "ProducerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProducerId", "dbo.Producers");
            DropIndex("dbo.Products", new[] { "ProducerId" });
        }
    }
}
