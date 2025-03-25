using System;
using System.Collections.Generic;
using JwtBearer_Treino.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtBearer_Treino.Contexts;

public partial class MainContext : DbContext
{
    public MainContext()
    {
    }

    public MainContext(DbContextOptions<MainContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Imagen> Imagens { get; set; }

    public virtual DbSet<Modalidade> Modalidades { get; set; }

    public virtual DbSet<Participante> Participantes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=XChallenge_Treino;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empresas__3214EC07F3D60389");

            entity.Property(e => e.Cnpj)
                .HasMaxLength(20)
                .HasColumnName("CNPJ");
            entity.Property(e => e.Endereco).HasMaxLength(150);
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Responsavel).HasMaxLength(100);
        });

        modelBuilder.Entity<Imagen>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Imagens__3214EC07D586AAB2");

            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.Tipo).HasMaxLength(50);
        });

        modelBuilder.Entity<Modalidade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Modalida__3214EC07BC0854D1");

            entity.Property(e => e.DataCompeticao).HasColumnType("datetime");
            entity.Property(e => e.Local).HasMaxLength(100);
            entity.Property(e => e.Nome).HasMaxLength(100);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Modalidades)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK__Modalidad__Empre__3E52440B");
        });

        modelBuilder.Entity<Participante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Particip__3214EC07CABA932C");

            entity.Property(e => e.Nome).HasMaxLength(100);

            entity.HasOne(d => d.Modalidade).WithMany(p => p.Participantes)
                .HasForeignKey(d => d.ModalidadeId)
                .HasConstraintName("FK__Participa__Modal__4222D4EF");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Participantes)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Participa__Usuar__412EB0B6");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC075F8BA96C");

            entity.HasIndex(e => e.Email, "UQ__Usuarios__A9D10534B5347B40").IsUnique();

            entity.Property(e => e.HoraLogin).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nome).HasMaxLength(100);
            entity.Property(e => e.SenhaHash).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
