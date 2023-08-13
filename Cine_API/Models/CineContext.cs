using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cine_API.Models;

public partial class CineContext : DbContext
{
    public CineContext()
    {
    }

    public CineContext(DbContextOptions<CineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Audio> Audios { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Comidum> Comida { get; set; }

    public virtual DbSet<Entrada> Entradas { get; set; }

    public virtual DbSet<Estatus> Estatuses { get; set; }

    public virtual DbSet<Historial> Historials { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Pelicula> Peliculas { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SalaCine> SalaCines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Audio>(entity =>
        {
            entity.HasKey(e => e.Audio1);

            entity.ToTable("Audio");

            entity.Property(e => e.Audio1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("audio");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Correo_Electronico");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rol");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario");

            entity.HasOne(d => d.RolNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.Rol)
                .HasConstraintName("FK_Clientes_roles");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("FK_Clientes_Estatus");
        });

        modelBuilder.Entity<Comidum>(entity =>
        {
            entity.HasKey(e => e.IdComida);

            entity.Property(e => e.IdComida).HasColumnName("ID_comida");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.Precio)
                .HasColumnType("money")
                .HasColumnName("precio");
        });

        modelBuilder.Entity<Entrada>(entity =>
        {
            entity.HasKey(e => e.IdEntradas);

            entity.Property(e => e.IdEntradas).HasColumnName("ID_Entradas");
            entity.Property(e => e.Asiento)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");
            entity.Property(e => e.IdHorario).HasColumnName("ID_Horario");
            entity.Property(e => e.Precio).HasColumnType("money");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Entrada)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Entradas_Clientes");

            entity.HasOne(d => d.IdHorarioNavigation).WithMany(p => p.Entrada)
                .HasForeignKey(d => d.IdHorario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Entradas_Horario");
        });

        modelBuilder.Entity<Estatus>(entity =>
        {
            entity.HasKey(e => e.Estatus1);

            entity.ToTable("Estatus");

            entity.Property(e => e.Estatus1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("estatus");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Historial>(entity =>
        {
            entity.HasKey(e => e.IdRegistro);

            entity.ToTable("Historial");

            entity.Property(e => e.IdRegistro).HasColumnName("ID_registro");
            entity.Property(e => e.Fecha).HasColumnType("date");
            entity.Property(e => e.HoraInicio).HasColumnName("Hora_inicio");
            entity.Property(e => e.IdHorario).HasColumnName("ID_Horario");
            entity.Property(e => e.IdPelicula).HasColumnName("ID_Pelicula");
            entity.Property(e => e.IdSala).HasColumnName("ID_Sala");

            entity.HasOne(d => d.IdHorarioNavigation).WithMany(p => p.Historials)
                .HasForeignKey(d => d.IdHorario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historial_Horario");

            entity.HasOne(d => d.IdPeliculaNavigation).WithMany(p => p.Historials)
                .HasForeignKey(d => d.IdPelicula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historial_Peliculas");

            entity.HasOne(d => d.IdSalaNavigation).WithMany(p => p.Historials)
                .HasForeignKey(d => d.IdSala)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historial_Sala_Cine");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.IdHorario);

            entity.ToTable("Horario");

            entity.Property(e => e.IdHorario).HasColumnName("ID_Horario");
            entity.Property(e => e.HoraInicio).HasColumnName("Hora_Inicio");
            entity.Property(e => e.IdPelicula).HasColumnName("ID_Pelicula");
            entity.Property(e => e.IdSala).HasColumnName("ID_Sala");

            entity.HasOne(d => d.IdPeliculaNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdPelicula)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Horario_Peliculas");

            entity.HasOne(d => d.IdSalaNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdSala)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Horario_Sala_Cine");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.ToTable("Pedido");

            entity.Property(e => e.IdCliente)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID_Cliente");
            entity.Property(e => e.IdComida).HasColumnName("ID_comida");
            entity.Property(e => e.IdEntradas).HasColumnName("ID_Entradas");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdClienteNavigation).WithOne(p => p.Pedido)
                .HasForeignKey<Pedido>(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedido_Clientes");

            entity.HasOne(d => d.IdComidaNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdComida)
                .HasConstraintName("FK_Pedido_Comida");

            entity.HasOne(d => d.IdEntradasNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdEntradas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Pedido_Entradas");
        });

        modelBuilder.Entity<Pelicula>(entity =>
        {
            entity.HasKey(e => e.IdPelicula);

            entity.Property(e => e.IdPelicula).HasColumnName("ID_Pelicula");
            entity.Property(e => e.Duracion)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Genero)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Idioma)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("idioma");
            entity.Property(e => e.Poster).IsUnicode(false);
            entity.Property(e => e.Sinopsis)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Trailer)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("trailer");

            entity.HasOne(d => d.IdiomaNavigation).WithMany(p => p.Peliculas)
                .HasForeignKey(d => d.Idioma)
                .HasConstraintName("FK_Peliculas_Audio");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Peliculas)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("FK_Peliculas_Estatus");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Rol);

            entity.ToTable("roles");

            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<SalaCine>(entity =>
        {
            entity.HasKey(e => e.IdSala);

            entity.ToTable("Sala_Cine");

            entity.Property(e => e.IdSala).HasColumnName("ID_Sala");
            entity.Property(e => e.CapacidadSala).HasColumnName("Capacidad_Sala");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.SalaCines)
                .HasForeignKey(d => d.Status)
                .HasConstraintName("FK_Sala_Cine_Estatus");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
