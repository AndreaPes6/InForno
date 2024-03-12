namespace InForno.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Checkout")]
    public partial class Checkout
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Checkout()
        {
            ProdottoOrdinato = new HashSet<ProdottoOrdinato>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int UtenteID { get; set; }

        [Required]
        [StringLength(50)]
        public string IndirizzoSpedizione { get; set; }

        [Required]
        [StringLength(500)]
        public string NoteUtili { get; set; }

        public DateTime DataOrdine { get; set; }

        public bool Stato { get; set; }

        public decimal TotalePrezzo { get; set; }

        public virtual Utenti Utenti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProdottoOrdinato> ProdottoOrdinato { get; set; }
    }
}
