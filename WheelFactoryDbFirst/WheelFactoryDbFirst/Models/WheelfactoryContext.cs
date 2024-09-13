using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WheelFactoryDbFirst.Models;

public partial class WheelfactoryContext : DbContext
{
    public WheelfactoryContext()
    {
    }

    public WheelfactoryContext(DbContextOptions<WheelfactoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Slevel> Slevels { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=localhost;initial catalog=wheelfactory;integrated security=true;trustservercertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("attendance");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("PK__colors__72E12F1A101157AB");

            entity.ToTable("colors");

            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__orders__3213E83FCE885E4B");

            entity.ToTable("orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Customername)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("customername");
        });

        modelBuilder.Entity<Slevel>(entity =>
        {
            entity.HasKey(e => e.Name).HasName("PK__slevels__72E12F1A2DFF67FC");

            entity.ToTable("slevels");

            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Taskid).HasName("PK__task__DD5E468AB0038DB8");

            entity.ToTable("task");

            entity.Property(e => e.Taskid).HasColumnName("taskid");
            entity.Property(e => e.Orderno).HasColumnName("orderno");
            entity.Property(e => e.Tasktype)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("tasktype");

            entity.HasOne(d => d.OrdernoNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Orderno)
                .HasConstraintName("FK__task__orderno__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
