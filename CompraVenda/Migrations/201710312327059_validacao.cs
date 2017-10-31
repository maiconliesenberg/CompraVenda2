namespace CompraVenda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validacao : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vendas", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendas", "Name", c => c.String());
        }
    }
}
