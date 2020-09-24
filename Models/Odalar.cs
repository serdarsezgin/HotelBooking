namespace OtelArama.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Odalar")]
    public partial class Odalar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Odalar()
        {
            Rezervasyon = new HashSet<Rezervasyon>();
            RezerveOdalar = new HashSet<RezerveOdalar>();
            UcretHesap = new HashSet<UcretHesap>();
        }

        [Key]
        public int oda_id { get; set; }

        public int otel_id { get; set; }

        public int odatip_id { get; set; }

        public int? oda_kat { get; set; }

        [StringLength(50)]
        public string oda_numara { get; set; }

        [StringLength(50)]
        public string odadurumu { get; set; }

        [StringLength(200)]
        public string image { get; set; }

        public int? oda_fiyat { get; set; }

        public virtual OdaTipi OdaTipi { get; set; }

        public virtual Oteller Oteller { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezervasyon> Rezervasyon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RezerveOdalar> RezerveOdalar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UcretHesap> UcretHesap { get; set; }
    }
}
