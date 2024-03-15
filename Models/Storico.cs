using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InForno.Models
{
    public class Storico
    {
        public int ID { get; set; }

        public int UtenteID { get; set; }

        public int ProdottoID { get; set; }

        [Column(TypeName = "decimal")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Prezzo { get; set; }

        public int Quantità { get; set; }

        public int NumeroOrdine { get; set; }

        public bool Stato { get; set; }

        public DateTime DataOrdine { get; set; }

        [ForeignKey("ProdottoID")]
        public virtual Prodotto Prodotto { get; set; }

        [ForeignKey("UtenteID")]
        public virtual Utenti Utente { get; set; }
    }
}
