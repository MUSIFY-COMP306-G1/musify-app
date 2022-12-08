using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MusifyApp.Models;

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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=musify.cgzfhdlykwpd.ca-central-1.rds.amazonaws.com,1433;Database=musify;TrustServerCertificate=True;User ID=admin;Password=password;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasKey(e => e.SongId).HasName("PK__Songs__12E3D6F78CF44802");

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
