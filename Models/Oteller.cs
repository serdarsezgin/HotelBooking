namespace OtelArama.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Oteller")]
    public partial class Oteller
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Oteller()
        {
            Odalar = new HashSet<Odalar>();
            Rezervasyon = new HashSet<Rezervasyon>();
        }

        [Key]
        public int otel_id { get; set; }

        public int yonetim_id { get; set; }

        [StringLength(50)]
        public string otel_adi { get; set; }

        [StringLength(50)]
        public string otel_adres { get; set; }

        [StringLength(50)]
        public string otel_tel { get; set; }

        [StringLength(200)]
        public string image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Odalar> Odalar { get; set; }

        public virtual OtelYonetimi OtelYonetimi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezervasyon> Rezervasyon { get; set; }
    }
}
