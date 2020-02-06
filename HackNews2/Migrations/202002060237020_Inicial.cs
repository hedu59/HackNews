namespace HackNews2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comentarios = c.String(),
                        AutorComentario = c.String(),
                        Data = c.DateTime(nullable: false),
                        NoticiaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Noticias", t => t.NoticiaId, cascadeDelete: true)
                .Index(t => t.NoticiaId);
            
            CreateTable(
                "dbo.Noticias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        ConteudoNoticia = c.String(),
                        Data = c.DateTime(nullable: false),
                        AutorNoticia = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comentarios", "NoticiaId", "dbo.Noticias");
            DropIndex("dbo.Comentarios", new[] { "NoticiaId" });
            DropTable("dbo.Noticias");
            DropTable("dbo.Comentarios");
        }
    }
}
