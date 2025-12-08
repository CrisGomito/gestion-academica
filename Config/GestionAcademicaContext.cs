using System;
using System.Collections.Generic;
using Gestion_Academica.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Academica.Config;

public partial class GestionAcademicaContext : DbContext
{
    public GestionAcademicaContext()
    {
    }

    public GestionAcademicaContext(DbContextOptions<GestionAcademicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calificacione> Calificaciones { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<EventosAutomatizacion> EventosAutomatizacions { get; set; }

    public virtual DbSet<Inscripcione> Inscripciones { get; set; }

    public virtual DbSet<Materia> Materias { get; set; }

    public virtual DbSet<Periodo> Periodos { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Gestion_Academica;Uid=cris;Pwd=12345;TrustServerCertificate = True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<Calificacione>(entity =>
        {
            entity.HasKey(e => e.CalificacionId).HasName("PK__Califica__4CF54ADE9F3AAF91");

            entity.Property(e => e.FechaEvaluacion).HasDefaultValueSql("(CONVERT([date],getdate()))");

            entity.HasOne(d => d.Inscripcion).WithMany(p => p.Calificaciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Calificaciones_Inscripcion");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.CursoId).HasName("PK__Cursos__7E0235D742794A9D");

            entity.HasOne(d => d.Materia).WithMany(p => p.Cursos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cursos_Materia");

            entity.HasOne(d => d.Periodo).WithMany(p => p.Cursos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cursos_Periodo");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.EstudianteId).HasName("PK__Estudian__6F7682D837074E68");

            entity.Property(e => e.EsActivo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(sysutcdatetime())");
        });

        modelBuilder.Entity<EventosAutomatizacion>(entity =>
        {
            entity.HasKey(e => e.EventoId).HasName("PK__EventosA__1EEB59211D796EA3");

            entity.Property(e => e.FechaEvento).HasDefaultValueSql("(sysutcdatetime())");
        });

        modelBuilder.Entity<Inscripcione>(entity =>
        {
            entity.HasKey(e => e.InscripcionId).HasName("PK__Inscripc__168316B935BE8DFB");

            entity.Property(e => e.Estado).HasDefaultValue("Matriculado");
            entity.Property(e => e.FechaInscripcion).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Curso).WithMany(p => p.Inscripciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inscripciones_Curso");

            entity.HasOne(d => d.Estudiante).WithMany(p => p.Inscripciones)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Inscripciones_Estudiante");
        });

        modelBuilder.Entity<Materia>(entity =>
        {
            entity.HasKey(e => e.MateriaId).HasName("PK__Materias__0D019DE19A4ED61C");

            entity.Property(e => e.EsActiva).HasDefaultValue(true);
        });

        modelBuilder.Entity<Periodo>(entity =>
        {
            entity.HasKey(e => e.PeriodoId).HasName("PK__Periodos__0ADD352A9F5AC92C");

            entity.Property(e => e.EsActivo).HasDefaultValue(true);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7B872073525");

            entity.Property(e => e.EsActivo).HasDefaultValue(true);
            entity.Property(e => e.FechaCreacion).HasDefaultValueSql("(getdate())");

            entity.HasMany(d => d.Rols).WithMany(p => p.Usuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RolId")
                        .HasConstraintName("FK_UsuarioRoles_Roles"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UsuarioRoles_Usuarios"),
                    j =>
                    {
                        j.HasKey("UsuarioId", "RolId");
                        j.ToTable("UsuarioRoles", "academico");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
