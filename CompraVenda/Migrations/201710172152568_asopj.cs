namespace CompraVenda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asopj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendas", "ClienteId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vendas", "ClienteId");
        }
    }
}
