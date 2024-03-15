namespace InForno.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CreateDatabaseTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Storico",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    UtenteID = c.Int(nullable: false),
                    ProdottoID = c.Int(nullable: false),
                    Prezzo = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Quantità = c.Int(nullable: false),
                    NumeroOrdine = c.Int(nullable: false),
                    Stato = c.Boolean(nullable: false),
                    DataOrdine = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Prodotto", t => t.ProdottoID, cascadeDelete: true)
                .ForeignKey("dbo.Utenti", t => t.UtenteID, cascadeDelete: true)
                .Index(t => t.UtenteID)
                .Index(t => t.ProdottoID);


        }

        public override void Down()
        {
            DropForeignKey("dbo.Storico", "UtenteID", "dbo.Utenti");
            DropForeignKey("dbo.Storico", "ProdottoID", "dbo.Prodotto");
            DropIndex("dbo.Storico", new[] { "ProdottoID" });
            DropIndex("dbo.Storico", new[] { "UtenteID" });
            DropTable("dbo.Storico");
        }
    }
}
