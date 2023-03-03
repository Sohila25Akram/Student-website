namespace secondProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblTeacher")]
    public partial class tblTeacher
    {
        public int id { get; set; }

        [StringLength(50)]
        public string tcname { get; set; }

        public decimal? tcage { get; set; }

        [StringLength(150)]
        public string tcaddress { get; set; }

        [StringLength(50)]
        public string tcemail { get; set; }

        [StringLength(12)]
        public string telphone { get; set; }

        public int? depId { get; set; }

        public virtual tblDepartment tblDepartment { get; set; }
    }
}
