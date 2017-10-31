namespace CompraVenda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clientes", "Name", c => c.String());
            AlterColumn("dbo.Produtoes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Produtoes", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Clientes", "Name", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
