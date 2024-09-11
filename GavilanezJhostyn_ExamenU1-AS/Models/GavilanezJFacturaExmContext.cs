using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GavilanezJhostyn_ExamenU1_AS.Models;

public partial class GavilanezJFacturaExmContext : DbContext
{
    public GavilanezJFacturaExmContext()
    {
    }

    public GavilanezJFacturaExmContext(DbContextOptions<GavilanezJFacturaExmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cabecera> Cabeceras { get; set; }

    public virtual DbSet<Detalle> Detalles { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);Database=GavilanezJ_FacturaExm;User Id=sa;Password=jhostyn;TrustServerCertificate=True;");
    */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cabecera>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cabecera__3214EC079630CC9D");

            entity.ToTable("Cabecera");

            entity.Property(e => e.Cliente).HasMaxLength(255);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
        });

        modelBuilder.Entity<Detalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Detalle__3214EC0708B6CE92");

            entity.ToTable("Detalle");

            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Cabecera).WithMany(p => p.Detalles)
                .HasForeignKey(d => d.CabeceraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle__Cabecer__286302EC");

            entity.HasOne(d => d.Producto).WithMany(p => p.Detalles)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle__Product__29572725");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC078B8285A5");

            entity.ToTable("Producto");

            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
