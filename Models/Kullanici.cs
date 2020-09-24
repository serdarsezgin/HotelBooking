namespace OtelArama.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanici")]
    public partial class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            Musteri = new HashSet<Musteri>();
            OtelYonetimi = new HashSet<OtelYonetimi>();
        }

        [Key]
        public int kullanici_id { get; set; }

        [StringLength(50)]
        public string kullanici_adi { get; set; }

        [StringLength(50)]
        public string kullanici_turu { get; set; }

        [StringLength(50)]
        public string kullanici_sifre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Musteri> Musteri { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OtelYonetimi> OtelYonetimi { get; set; }
    }
}
