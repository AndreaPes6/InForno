namespace InForno.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProdottoOrdinato")]
    public partial class ProdottoOrdinato
    {
        public int ID { get; set; }

        public int CheckoutID { get; set; }

        public int ProdottiID { get; set; }

        public int Quantità { get; set; }

        public virtual Checkout Checkout { get; set; }

        public virtual Prodotto Prodotto { get; set; }
    }
}
