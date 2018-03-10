namespace AspNetOwin.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dados",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nome = c.String(nullable: false),
                        CPF = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Enderecos",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Logradouro = c.String(),
                        N = c.String(),
                        Complemento = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        UF = c.String(),
                        CEP = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enderecos", "Id", "dbo.Clientes");
            DropForeignKey("dbo.Dados", "Id", "dbo.Clientes");
            DropIndex("dbo.Enderecos", new[] { "Id" });
            DropIndex("dbo.Dados", new[] { "Id" });
            DropTable("dbo.Enderecos");
            DropTable("dbo.Dados");
            DropTable("dbo.Clientes");
        }
    }
}
