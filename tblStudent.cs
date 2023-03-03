namespace secondProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblStudent")]
    public partial class tblStudent
    {
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public decimal? age { get; set; }

        [StringLength(150)]
        public string address { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        public DateTime? birthdate { get; set; }

        [StringLength(12)]
        public string password { get; set; }

        public int? classNum { get; set; }

        public bool isActive { get; set; }

        public bool? isActive2 { get; set; }
    }
}
