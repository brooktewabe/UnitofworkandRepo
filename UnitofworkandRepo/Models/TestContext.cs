using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UnitofworkandRepo.Models;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Mytbl> Mytbls { get; set; }

    public virtual DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mytbl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mytbl_pkey");

            entity.ToTable("mytbl");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Greet)
                .HasMaxLength(50)
                .HasColumnName("greet");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
