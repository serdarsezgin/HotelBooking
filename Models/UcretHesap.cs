namespace OtelArama.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UcretHesap")]
    public partial class UcretHesap
    {
        public int id { get; set; }

        public int oda_id { get; set; }

        public int rez_id { get; set; }

        [StringLength(50)]
        public string tutar { get; set; }

        public virtual Odalar Odalar { get; set; }

        public virtual Rezervasyon Rezervasyon { get; set; }
    }
}
