using ADL.Models.db_Models.Interfaces;
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
        }

        private void ConfigureMeasurementSource(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeasurementSource>().HasOne(t => t.Type);
            modelBuilder.Entity<MeasurementSource>().Property(p => p.Rowversion).IsConcurrencyToken();
        }

    }
}
