using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityDatabaseFirst.Models;

public partial class TokioProyectoContext : DbContext
{
    public TokioProyectoContext()
    {
    }

    public TokioProyectoContext(DbContextOptions<TokioProyectoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Balance> Balances { get; set; }

    public virtual DbSet<CambiosPersona> CambiosPersonas { get; set; }

    public virtual DbSet<CategoriaMateriaPrima> CategoriaMateriaPrimas { get; set; }

    public virtual DbSet<CategoriaProducto> CategoriaProductos { get; set; }

    public virtual DbSet<Colore> Colores { get; set; }

    public virtual DbSet<Documento> Documentos { get; set; }

    public virtual DbSet<MateriaPrima> MateriaPrimas { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Registro> Registros { get; set; }

    public virtual DbSet<Talla> Tallas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=server_name;Database=TOKIO-PROYECTO;User=*****;Password=********;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Balance>(entity =>
        {
            entity.ToTable("Balance");

            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Producto)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CambiosPersona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CambiosP__3214EC07706B3FB9");

            entity.Property(e => e.CamposModificados).IsUnicode(false);
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.TipoCambio)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ValoresAntiguos).IsUnicode(false);
            entity.Property(e => e.ValoresNuevos).IsUnicode(false);
        });

        modelBuilder.Entity<CategoriaMateriaPrima>(entity =>
        {
            entity.ToTable("CategoriaMateriaPrima");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MedidaCategoria)
                .HasMaxLength(50)
                .HasColumnName("medidaCategoria");
            entity.Property(e => e.NombreCategoria)
                .HasMaxLength(50)
                .HasColumnName("nombreCategoria");
        });

        modelBuilder.Entity<CategoriaProducto>(entity =>
        {
            entity.HasKey(e => e.IdCategoria);

            entity.ToTable("CategoriaProducto");

            entity.Property(e => e.Categoria).HasMaxLength(50);
        });

        modelBuilder.Entity<Colore>(entity =>
        {
            entity.HasKey(e => e.IdColor);

            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Documento>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<MateriaPrima>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MateriaP__3213E83F717A7672");

            entity.ToTable("MateriaPrima");

            entity.HasIndex(e => e.FechaCompra, "IX_MateriaPrima");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoriaId).HasColumnName("categoriaId");
            entity.Property(e => e.ColorId).HasColumnName("colorId");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaCompra)
                .HasColumnType("date")
                .HasColumnName("fechaCompra");
            entity.Property(e => e.Nombre)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio).HasColumnName("precio");
            entity.Property(e => e.ProveedorId).HasColumnName("proveedorId");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.Categoria).WithMany(p => p.MateriaPrimas)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MateriaPrima_CategoriaMateriaPrima");

            entity.HasOne(d => d.Color).WithMany(p => p.MateriaPrimas)
                .HasForeignKey(d => d.ColorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MateriaPrima_Colores");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("RegistroCambios"));

            entity.Property(e => e.Cedula).IsUnicode(false);
            entity.Property(e => e.Correo).IsUnicode(false);
            entity.Property(e => e.Edad)
                .HasColumnType("date")
                .HasColumnName("edad");
            entity.Property(e => e.Imagen)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.Nombre).IsUnicode(false);
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasDefaultValueSql("('null')");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Idproducto).HasName("PK__Producto__A543D3ED07A27A41");

            entity.Property(e => e.Idproducto).HasColumnName("IDproducto");
            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Categoria).IsUnicode(false);
            entity.Property(e => e.Color).IsUnicode(false);
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.Nombre).IsUnicode(false);
            entity.Property(e => e.Talla).IsUnicode(false);
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proveedo__3213E83F882C1B19");

            entity.ToTable("Proveedor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.CedulaRuc)
                .IsUnicode(false)
                .HasColumnName("cedula_ruc");
            entity.Property(e => e.Correo)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Nombre)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Registro>(entity =>
        {
            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.IdProducto)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Registros)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Registro_Usuario");
        });

        modelBuilder.Entity<Talla>(entity =>
        {
            entity.HasKey(e => e.IdTalla);

            entity.ToTable("Talla");

            entity.Property(e => e.Talla1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Talla");
        });
        modelBuilder.HasSequence<int>("indice")
            .HasMin(1L)
            .HasMax(1000L)
            .IsCyclic();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
