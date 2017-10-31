namespace CompraVenda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validacaonosmodels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Funcionarios", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Produtoes", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtoes", "Name", c => c.String());
            AlterColumn("dbo.Funcionarios", "Name", c => c.String());
            AlterColumn("dbo.Clientes", "Name", c => c.String());
        }
    }
}
