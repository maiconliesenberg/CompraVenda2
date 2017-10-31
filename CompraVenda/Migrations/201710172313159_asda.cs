namespace CompraVenda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asda : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendas", "ProdutoId", c => c.Byte(nullable: false));
            AddColumn("dbo.Vendas", "FuncionarioId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vendas", "FuncionarioId");
            DropColumn("dbo.Vendas", "ProdutoId");
        }
    }
}
