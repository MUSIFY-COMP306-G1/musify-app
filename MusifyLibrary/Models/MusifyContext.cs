using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MusifyLibrary.Models;

public partial class MusifyContext : DbContext
{
    public MusifyContext()
    {
    }

    public MusifyContext(DbContextOptions<MusifyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Song> Songs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasKey(e => e.SongId).HasName("PK__Songs__12E3D6F73BB09A3A");

            entity.Property(e => e.SongId)
                .ValueGeneratedNever()
                .HasColumnName("SongID");
            entity.Property(e => e.Album)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Artist)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Genre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SongName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
