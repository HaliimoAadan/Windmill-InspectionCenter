using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using efscaffold.Entities;

namespace Infrastructure.Postgres.Scaffolding;

public partial class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alert> Alerts { get; set; }

    public virtual DbSet<Command> Commands { get; set; }

    public virtual DbSet<Farm> Farms { get; set; }

    public virtual DbSet<Operator> Operators { get; set; }

    public virtual DbSet<Telemetry> Telemetries { get; set; }

    public virtual DbSet<Turbine> Turbines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alert>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("alert_pkey");

            entity.ToTable("alert", "windmill_inspection_center");

            entity.HasIndex(e => new { e.TurbineId, e.Timestamp }, "alert_turbine_id_timestamp_idx").IsDescending(false, true);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.Severity).HasColumnName("severity");
            entity.Property(e => e.Timestamp).HasColumnName("timestamp");
            entity.Property(e => e.TurbineId).HasColumnName("turbine_id");

            entity.HasOne(d => d.Turbine).WithMany(p => p.Alerts)
                .HasForeignKey(d => d.TurbineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("alert_turbine_id_fkey");
        });

        modelBuilder.Entity<Command>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("command_pkey");

            entity.ToTable("command", "windmill_inspection_center");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action).HasColumnName("action");
            entity.Property(e => e.IntervalSeconds).HasColumnName("interval_seconds");
            entity.Property(e => e.OperatorId).HasColumnName("operator_id");
            entity.Property(e => e.PitchAngle).HasColumnName("pitch_angle");
            entity.Property(e => e.Reason).HasColumnName("reason");
            entity.Property(e => e.Timestamp).HasColumnName("timestamp");
            entity.Property(e => e.TurbineId).HasColumnName("turbine_id");

            entity.HasOne(d => d.Operator).WithMany(p => p.Commands)
                .HasForeignKey(d => d.OperatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("command_operator_id_fkey");

            entity.HasOne(d => d.Turbine).WithMany(p => p.Commands)
                .HasForeignKey(d => d.TurbineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("command_turbine_id_fkey");
        });

        modelBuilder.Entity<Farm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("farm_pkey");

            entity.ToTable("farm", "windmill_inspection_center");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Operator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("operator_pkey");

            entity.ToTable("operator", "windmill_inspection_center");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
            entity.Property(e => e.Username).HasColumnName("username");
        });

        modelBuilder.Entity<Telemetry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("telemetry_pkey");

            entity.ToTable("telemetry", "windmill_inspection_center");

            entity.HasIndex(e => new { e.TurbineId, e.Timestamp }, "telemetry_turbine_id_timestamp_idx").IsDescending(false, true);

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AmbientTemperature).HasColumnName("ambient_temperature");
            entity.Property(e => e.BladePitch).HasColumnName("blade_pitch");
            entity.Property(e => e.FarmId).HasColumnName("farm_id");
            entity.Property(e => e.GearboxTemp).HasColumnName("gearbox_temp");
            entity.Property(e => e.GeneratorTemp).HasColumnName("generator_temp");
            entity.Property(e => e.NacelleDirection).HasColumnName("nacelle_direction");
            entity.Property(e => e.PowerOutput).HasColumnName("power_output");
            entity.Property(e => e.RotorSpeed).HasColumnName("rotor_speed");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Timestamp).HasColumnName("timestamp");
            entity.Property(e => e.TurbineId).HasColumnName("turbine_id");
            entity.Property(e => e.Vibration).HasColumnName("vibration");
            entity.Property(e => e.WindDirection).HasColumnName("wind_direction");
            entity.Property(e => e.WindSpeed).HasColumnName("wind_speed");

            entity.HasOne(d => d.Farm).WithMany(p => p.Telemetries)
                .HasForeignKey(d => d.FarmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("telemetry_farm_id_fkey");

            entity.HasOne(d => d.Turbine).WithMany(p => p.Telemetries)
                .HasForeignKey(d => d.TurbineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("telemetry_turbine_id_fkey");
        });

        modelBuilder.Entity<Turbine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("turbine_pkey");

            entity.ToTable("turbine", "windmill_inspection_center");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FarmId).HasColumnName("farm_id");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.Farm).WithMany(p => p.Turbines)
                .HasForeignKey(d => d.FarmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("turbine_farm_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
