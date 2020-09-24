namespace OtelArama.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Musteri")]
    public partial class Musteri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Musteri()
        {
            Rezervasyon = new HashSet<Rezervasyon>();
            Rezervasyon1 = new HashSet<Rezervasyon>();
        }

        [Key]
        public int musteri_id { get; set; }

        public int kullanici_id { get; set; }

        [StringLength(50)]
        public string musteri_adi { get; set; }

        [StringLength(50)]
        public string musteri_soyadi { get; set; }

        [StringLength(100)]
        public string musteri_adres { get; set; }

        [StringLength(50)]
        public string musteri_tel { get; set; }

        [StringLength(50)]
        public string musteri_email { get; set; }

        public virtual Kullanici Kullanici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezervasyon> Rezervasyon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezervasyon> Rezervasyon1 { get; set; }
    }
}
