namespace OtelArama.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class OtelAramaModel : DbContext
    {
        public OtelAramaModel()
            : base("name=OtelAramaModel1")
        {
        }

        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<Odalar> Odalar { get; set; }
        public virtual DbSet<OdaTipi> OdaTipi { get; set; }
        public virtual DbSet<Oteller> Oteller { get; set; }
        public virtual DbSet<OtelYonetimi> OtelYonetimi { get; set; }
        public virtual DbSet<Rezervasyon> Rezervasyon { get; set; }
        public virtual DbSet<RezervasyonDurum> RezervasyonDurum { get; set; }
        public virtual DbSet<RezerveOdalar> RezerveOdalar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kullanici>()
                .Property(e => e.kullanici_adi)
                .IsUnicode(false);

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.kullanici_turu)
                .IsUnicode(false);

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.kullanici_sifre)
                .IsFixedLength();

            modelBuilder.Entity<Musteri>()
                .Property(e => e.musteri_adi)
                .IsUnicode(false);

            modelBuilder.Entity<Musteri>()
                .Property(e => e.musteri_soyadi)
                .IsUnicode(false);

            modelBuilder.Entity<Musteri>()
                .Property(e => e.musteri_adres)
                .IsUnicode(false);

            modelBuilder.Entity<Musteri>()
                .Property(e => e.musteri_tel)
                .IsUnicode(false);

            modelBuilder.Entity<Musteri>()
                .Property(e => e.musteri_email)
                .IsUnicode(false);

            modelBuilder.Entity<Musteri>()
                .HasMany(e => e.Rezervasyon)
                .WithRequired(e => e.Musteri)
                .HasForeignKey(e => e.musteri_id);

            modelBuilder.Entity<Musteri>()
                .HasMany(e => e.Rezervasyon1)
                .WithRequired(e => e.Musteri1)
                .HasForeignKey(e => e.musteri_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Odalar>()
                .Property(e => e.oda_numara)
                .IsUnicode(false);

            modelBuilder.Entity<Odalar>()
                .Property(e => e.odadurumu)
                .IsUnicode(false);

            modelBuilder.Entity<Odalar>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<Odalar>()
                .HasMany(e => e.Rezervasyon)
                .WithRequired(e => e.Odalar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Odalar>()
                .HasMany(e => e.RezerveOdalar)
                .WithRequired(e => e.Odalar)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OdaTipi>()
                .Property(e => e.odatipi1)
                .IsUnicode(false);

            modelBuilder.Entity<OdaTipi>()
                .Property(e => e.ot_aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<OdaTipi>()
                .HasMany(e => e.Odalar)
                .WithRequired(e => e.OdaTipi)
                .HasForeignKey(e => e.odatip_id);

            modelBuilder.Entity<Oteller>()
                .Property(e => e.otel_adi)
                .IsUnicode(false);

            modelBuilder.Entity<Oteller>()
                .Property(e => e.otel_adres)
                .IsUnicode(false);

            modelBuilder.Entity<Oteller>()
                .Property(e => e.otel_tel)
                .IsUnicode(false);

            modelBuilder.Entity<Oteller>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<Oteller>()
                .HasMany(e => e.Rezervasyon)
                .WithRequired(e => e.Oteller)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OtelYonetimi>()
                .Property(e => e.yonetim_adi)
                .IsUnicode(false);

            modelBuilder.Entity<OtelYonetimi>()
                .Property(e => e.yonetim_tel)
                .IsUnicode(false);

            modelBuilder.Entity<Rezervasyon>()
                .HasMany(e => e.RezerveOdalar)
                .WithRequired(e => e.Rezervasyon)
                .HasForeignKey(e => e.rez_id);

            modelBuilder.Entity<RezervasyonDurum>()
                .Property(e => e.durum)
                .IsUnicode(false);

            modelBuilder.Entity<RezervasyonDurum>()
                .HasMany(e => e.Rezervasyon)
                .WithRequired(e => e.RezervasyonDurum)
                .HasForeignKey(e => e.rezdurum_id);
        }
    }
}
