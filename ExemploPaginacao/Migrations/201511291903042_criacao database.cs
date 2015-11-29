namespace ExemploPaginacao.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criacaodatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Filme",
                c => new
                    {
                        FilmeId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        Diretor = c.String(maxLength: 100, unicode: false),
                        Ano = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilmeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Filme");
        }
    }
}
