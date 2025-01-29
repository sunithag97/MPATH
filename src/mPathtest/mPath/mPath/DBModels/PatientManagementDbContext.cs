using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace mPath.DBModels;

public partial class PatientManagementDbContext : DbContext
{
    public PatientManagementDbContext()
    {
    }

    public PatientManagementDbContext(DbContextOptions<PatientManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Recommendation> Recommendations { get; set; }

    public virtual DbSet<RecommendationType> RecommendationTypes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AuditLog__3214EC077F18FA6E");

            entity.ToTable("AuditLog");

            entity.Property(e => e.Action).HasMaxLength(2000);
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Details).HasMaxLength(2000);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Patient__3214EC077E8C5E13");

            entity.ToTable("Patient");

            entity.Property(e => e.DateOfBirth).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Recommendation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Recommen__3214EC0796151BEF");

            entity.ToTable("Recommendation");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Type).HasMaxLength(2000);

            entity.HasOne(d => d.Patient).WithMany(p => p.Recommendations)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Recommend__Patie__4222D4EF");
        });

        modelBuilder.Entity<RecommendationType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Recommen__3214EC07BEDB1F0B");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(2000);
            entity.Property(e => e.Type).HasMaxLength(2000);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
