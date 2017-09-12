namespace CompraVenda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSub : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "IsSub", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "IsSub");
        }
    }
}
