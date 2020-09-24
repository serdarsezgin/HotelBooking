namespace OtelArama.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OtelYonetimi")]
    public partial class OtelYonetimi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OtelYonetimi()
        {
            Oteller = new HashSet<Oteller>();
        }

        [Key]
        public int yonetim_id { get; set; }

        public int kullanici_id { get; set; }

        [StringLength(50)]
        public string yonetim_adi { get; set; }

        [StringLength(50)]
        public string yonetim_tel { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Oteller> Oteller { get; set; }
    }
}
