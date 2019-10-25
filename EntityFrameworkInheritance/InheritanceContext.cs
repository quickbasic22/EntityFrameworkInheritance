using EntityFrameworkInheritance.Models;
using System;
using System.Data.Entity;
using System.Linq;


namespace EntityFrameworkInheritance
{
    public class InheritanceContext : DbContext
    {
        public InheritanceContext(): base("name=InheritanceContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TPHCourse>()
                .Map<TPHOnlineCourse>(m => m.Requires("Type").HasValue("TPHOnlineCourse"))
                .Map<TPHOfflineCourse>(m => m.Requires("Type").HasValue("TPHOfflineCourse"));
            modelBuilder.Entity<TPCOnlineCourse>()
                .Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("TPCOnlineCourse");
                });
            modelBuilder.Entity<TPCOfflineCourse>()
                .Map(m =>
                {
                    m.MapInheritedProperties();
                    m.ToTable("TPCOfflineCourse");
                });
            modelBuilder.Entity<TPTCourse>().ToTable("TPTCourse");
            modelBuilder.Entity<TPTOnlineCourse>().ToTable("TPTOnlineCourse");
            modelBuilder.Entity<TPTOfflineCourse>().ToTable("TPTOfflineCourse");

        }

        public virtual DbSet<TPHCourse> TPHCourses { get; set; }
    }
}