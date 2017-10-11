namespace CompraVenda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendas", "cliente_Id", c => c.Int());
            AddColumn("dbo.Vendas", "Funcionario_Id", c => c.Int());
            AddColumn("dbo.Vendas", "Produto_Id", c => c.Int());
            AlterColumn("dbo.Clientes", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Produtoes", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Vendas", "cliente_Id");
            CreateIndex("dbo.Vendas", "Funcionario_Id");
            CreateIndex("dbo.Vendas", "Produto_Id");
            AddForeignKey("dbo.Vendas", "cliente_Id", "dbo.Clientes", "Id");
            AddForeignKey("dbo.Vendas", "Funcionario_Id", "dbo.Funcionarios", "Id");
            AddForeignKey("dbo.Vendas", "Produto_Id", "dbo.Produtoes", "Id");
        }
        
        public override void Down()
        {
            
            DropForeignKey("dbo.Vendas", "Produto_Id", "dbo.Produtoes");
            DropForeignKey("dbo.Vendas", "Funcionario_Id", "dbo.Funcionarios");
            DropForeignKey("dbo.Vendas", "cliente_Id", "dbo.Clientes");
            DropIndex("dbo.Vendas", new[] { "Produto_Id" });
            DropIndex("dbo.Vendas", new[] { "Funcionario_Id" });
            DropIndex("dbo.Vendas", new[] { "cliente_Id" });
            AlterColumn("dbo.Produtoes", "Name", c => c.String());
            AlterColumn("dbo.Clientes", "Name", c => c.String());
            DropColumn("dbo.Vendas", "Produto_Id");
            DropColumn("dbo.Vendas", "Funcionario_Id");
            DropColumn("dbo.Vendas", "cliente_Id");
        }
    }
}
