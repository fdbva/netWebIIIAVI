namespace AV1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fornecedors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        CNPJ = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Marca = c.String(nullable: false),
                        Estoque = c.Int(nullable: false),
                        Preco = c.Double(nullable: false),
                        FornecedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fornecedors", t => t.FornecedorId, cascadeDelete: true)
                .Index(t => t.FornecedorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produtoes", "FornecedorId", "dbo.Fornecedors");
            DropIndex("dbo.Produtoes", new[] { "FornecedorId" });
            DropTable("dbo.Produtoes");
            DropTable("dbo.Fornecedors");
        }
    }
}
