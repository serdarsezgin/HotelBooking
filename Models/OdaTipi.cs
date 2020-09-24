namespace OtelArama.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OdaTipi")]
    public partial class OdaTipi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OdaTipi()
        {
            Odalar = new HashSet<Odalar>();
        }

        [Key]
        public int ot_id { get; set; }

        [Column("odatipi")]
        [StringLength(50)]
        public string odatipi1 { get; set; }

        [StringLength(50)]
        public string ot_aciklama { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Odalar> Odalar { get; set; }
    }
}
