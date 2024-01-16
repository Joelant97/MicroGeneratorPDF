using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TemplateManagerAPI.Models;

public partial class TemplatemgrContext : DbContext
{
    public TemplatemgrContext(DbContextOptions<TemplatemgrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Template> Templates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Template>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Template__3214EC07B2F43CBA");

            entity.ToTable("Template");

            entity.Property(e => e.AddresseeName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AuthorName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Content)
                .HasMaxLength(2000)
                .IsUnicode(false);
            entity.Property(e => e.CurrentDate).HasColumnType("date");
            entity.Property(e => e.DesiredPosition)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FileType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
