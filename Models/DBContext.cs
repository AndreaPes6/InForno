using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using InForno.Models;

namespace InForno.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<Checkout> Checkout { get; set; }
        public virtual DbSet<Prodotto> Prodotto { get; set; }
        public virtual DbSet<Storico> Storico { get; set; }

        public virtual DbSet<ProdottoOrdinato> ProdottiOrdinati { get; set; }

        public virtual DbSet<Utenti> Utenti { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Checkout>()
                .HasMany(e => e.ProdottoOrdinato)
                .WithRequired(e => e.Checkout)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Prodotto>()
                .HasMany(e => e.ProdottoOrdinato)
                .WithRequired(e => e.Prodotto)
                .HasForeignKey(e => e.ProdottiID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Utenti>()
                .HasMany(e => e.Checkout)
                .WithRequired(e => e.Utenti)
                .HasForeignKey(e => e.UtenteID)
                .WillCascadeOnDelete(false);
        }
    }
}
