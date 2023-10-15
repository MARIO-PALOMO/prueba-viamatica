using System;
using System.Collections.Generic;
using consultorio_seguros_api.Entidad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace consultorio_seguros_api.Contexto
{
    public partial class svrlogsContext : DbContext
    {
        public svrlogsContext()
        {
        }

        public svrlogsContext(DbContextOptions<svrlogsContext> options)
            : base(options)
        {
        }

         public DbSet<Seguro> Seguro { get; set; }
        public DbSet<Asegurado> Asegurado { get; set; }
        public DbSet<SeguroAsegurado> SeguroAsegurado { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
