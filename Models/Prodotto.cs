namespace InForno.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prodotto")]
    public partial class Prodotto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prodotto()
        {
            ProdottoOrdinato = new HashSet<ProdottoOrdinato>();
        }

        public int ID { get; set; }

        public string Foto { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string Descrizione { get; set; }

        public decimal Prezzo { get; set; }

        public DateTime? TempoDiConsegna { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProdottoOrdinato> ProdottoOrdinato { get; set; }
    }
}
