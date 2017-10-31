namespace CompraVenda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetudo : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Vendas", new[] { "cliente_Id" });
            CreateIndex("dbo.Vendas", "Cliente_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Vendas", new[] { "Cliente_Id" });
            CreateIndex("dbo.Vendas", "cliente_Id");
        }
    }
}
