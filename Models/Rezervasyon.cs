namespace OtelArama.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rezervasyon")]
    public partial class Rezervasyon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rezervasyon()
        {
            RezerveOdalar = new HashSet<RezerveOdalar>();
            UcretHesap = new HashSet<UcretHesap>();
        }

        [Key]
        public int rezervasyon_id { get; set; }

        public int otel_id { get; set; }

        public int musteri_id { get; set; }

        public int oda_id { get; set; }

        public int rezdurum_id { get; set; }

        public DateTime? giristarihi { get; set; }

        public DateTime? cikistarihi { get; set; }

        public int? odasayisi { get; set; }

        public virtual Musteri Musteri { get; set; }

        public virtual Musteri Musteri1 { get; set; }

        public virtual Odalar Odalar { get; set; }

        public virtual Oteller Oteller { get; set; }

        public virtual RezervasyonDurum RezervasyonDurum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RezerveOdalar> RezerveOdalar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UcretHesap> UcretHesap { get; set; }
    }
}
