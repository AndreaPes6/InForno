namespace InForno.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prove : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Storico", "ProdottoID", "dbo.Prodotto");
            DropForeignKey("dbo.Storico", "Utenti_ID", "dbo.Utenti");
            DropForeignKey("dbo.Storico", "UtenteID", "dbo.Utenti");
            DropForeignKey("dbo.Storico", "Prodotto_ID", "dbo.Prodotto");
            DropIndex("dbo.Storico", new[] { "UtenteID" });
            DropIndex("dbo.Storico", new[] { "ProdottoID" });
            DropIndex("dbo.Storico", new[] { "Utenti_ID" });
            DropIndex("dbo.Storico", new[] { "Prodotto_ID" });
            DropColumn("dbo.ProdottoOrdinato", "Stato");
            DropTable("dbo.Storico");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Storico",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UtenteID = c.Int(nullable: false),
                        ProdottoID = c.Int(nullable: false),
                        Prezzo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantita = c.Int(nullable: false),
                        NumeroOrdine = c.Int(nullable: false),
                        Stato = c.Boolean(nullable: false),
                        DataOrdine = c.DateTime(nullable: false),
                        Utenti_ID = c.Int(),
                        Prodotto_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.ProdottoOrdinato", "Stato", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Storico", "Prodotto_ID");
            CreateIndex("dbo.Storico", "Utenti_ID");
            CreateIndex("dbo.Storico", "ProdottoID");
            CreateIndex("dbo.Storico", "UtenteID");
            AddForeignKey("dbo.Storico", "Prodotto_ID", "dbo.Prodotto", "ID");
            AddForeignKey("dbo.Storico", "UtenteID", "dbo.Utenti", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Storico", "Utenti_ID", "dbo.Utenti", "ID");
            AddForeignKey("dbo.Storico", "ProdottoID", "dbo.Prodotto", "ID", cascadeDelete: true);
        }
    }
}
