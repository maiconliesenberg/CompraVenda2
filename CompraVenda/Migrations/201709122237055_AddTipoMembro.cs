namespace CompraVenda.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTipoMembro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoMembroes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SingUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Clientes", "tipoMembro_Id", c => c.Byte());
            CreateIndex("dbo.Clientes", "tipoMembro_Id");
            AddForeignKey("dbo.Clientes", "tipoMembro_Id", "dbo.TipoMembroes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientes", "tipoMembro_Id", "dbo.TipoMembroes");
            DropIndex("dbo.Clientes", new[] { "tipoMembro_Id" });
            DropColumn("dbo.Clientes", "tipoMembro_Id");
            DropTable("dbo.TipoMembroes");
        }
    }
}
