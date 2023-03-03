using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace secondProject
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<tblDepartment> tblDepartments { get; set; }
        public virtual DbSet<tblStudent> tblStudents { get; set; }
        public virtual DbSet<tblTeacher> tblTeachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblDepartment>()
                .HasMany(e => e.tblTeachers)
                .WithOptional(e => e.tblDepartment)
                .HasForeignKey(e => e.depId);
        }
    }
}
