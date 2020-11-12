namespace VagtplanWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Afdelingsplan")]
    public partial class Afdelingsplan
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MedarbejderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VagtID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Dato { get; set; }

        public int VirksomhedsID { get; set; }

        public virtual Medarbejdersplan Medarbejdersplan { get; set; }

        public virtual Vagtplan Vagtplan { get; set; }

        public virtual Virksomhed Virksomhed { get; set; }
    }
}
