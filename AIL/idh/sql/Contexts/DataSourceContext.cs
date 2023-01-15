using ADL.Models.db_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AIL.idh.sql.Contexts
{
    public class DataSourceContext : DbContext
    {
        public DbSet<MeasurementSource> Source { get; set; }
        public DbSet<MeasurementType> Type { get; set; }

        public DataSourceContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureMeasurementSource(modelBuilder);
            ConfigureMeasurementType(modelBuilder);
        }

        private void ConfigureMeasurementSource(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<MeasurementSource>().Property(p => p.Rowversion).IsConcurrencyToken();
        }

        private void ConfigureMeasurementType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeasurementType>().HasOne(x => x.ParentSource).WithOne(y => y.Type).HasForeignKey<MeasurementSource>(z => z.Id);
            modelBuilder.Entity<MeasurementType>().Property(p => p.Rowversion).IsConcurrencyToken();
        }

    }
}
