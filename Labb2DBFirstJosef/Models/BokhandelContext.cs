using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Labb2DBFirstJosef.Models;

public partial class BokhandelContext : DbContext
{
    public BokhandelContext()
    {
    }

    public BokhandelContext(DbContextOptions<BokhandelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Butiker> Butikers { get; set; }

    public virtual DbSet<Böcker> Böckers { get; set; }

    public virtual DbSet<Författare> Författares { get; set; }

    public virtual DbSet<Förlag> Förlags { get; set; }

    public virtual DbSet<Kunder> Kunders { get; set; }

    public virtual DbSet<LagerSaldo> LagerSaldos { get; set; }

    public virtual DbSet<OrderRader> OrderRaders { get; set; }

    public virtual DbSet<Ordrar> Ordrars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Bokhandel;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Butiker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Butiker__3214EC27E9A8CBCB");

            entity.ToTable("Butiker");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Adress).HasMaxLength(100);
            entity.Property(e => e.Namn).HasMaxLength(100);
            entity.Property(e => e.Postnummer).HasMaxLength(10);
            entity.Property(e => e.Stad).HasMaxLength(100);
        });

        modelBuilder.Entity<Böcker>(entity =>
        {
            entity.HasKey(e => e.Isbn13).HasName("PK__Böcker__3BF79E0361F39C02");

            entity.ToTable("Böcker");

            entity.Property(e => e.Isbn13)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISBN13");
            entity.Property(e => e.FörfattareId).HasColumnName("FörfattareID");
            entity.Property(e => e.FörlagsId).HasColumnName("FörlagsID");
            entity.Property(e => e.Pris).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Språk).HasMaxLength(30);
            entity.Property(e => e.Titel).HasMaxLength(100);

            entity.HasOne(d => d.Författare).WithMany(p => p.Böckers)
                .HasForeignKey(d => d.FörfattareId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Böcker__Författa__59FA5E80");

            entity.HasOne(d => d.Förlags).WithMany(p => p.Böckers)
                .HasForeignKey(d => d.FörlagsId)
                .HasConstraintName("FK__Böcker__FörlagsI__5AEE82B9");
        });

        modelBuilder.Entity<Författare>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Författa__3214EC27620455E6");

            entity.ToTable("Författare");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Efternamn).HasMaxLength(50);
            entity.Property(e => e.Förnamn).HasMaxLength(50);
        });

        modelBuilder.Entity<Förlag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Förlag__3214EC27116BE56C");

            entity.ToTable("Förlag");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Kontaktperson).HasMaxLength(50);
            entity.Property(e => e.Namn).HasMaxLength(100);
            entity.Property(e => e.Telefon).HasMaxLength(20);
        });

        modelBuilder.Entity<Kunder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Kunder__3214EC275B50C9AA");

            entity.ToTable("Kunder");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Efternamn).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Förnamn).HasMaxLength(50);
            entity.Property(e => e.Telefon).HasMaxLength(20);
        });

        modelBuilder.Entity<LagerSaldo>(entity =>
        {
            entity.HasKey(e => new { e.ButikId, e.Isbn13 }).HasName("PK__LagerSal__9669121A92CB2981");

            entity.ToTable("LagerSaldo");

            entity.Property(e => e.ButikId).HasColumnName("ButikID");
            entity.Property(e => e.Isbn13)
                .HasMaxLength(13)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ISBN13");

            entity.HasOne(d => d.Butik).WithMany(p => p.LagerSaldos)
                .HasForeignKey(d => d.ButikId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LagerSald__Butik__5BE2A6F2");

            entity.HasOne(d => d.Isbn13Navigation).WithMany(p => p.LagerSaldos)
                .HasForeignKey(d => d.Isbn13)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LagerSald__ISBN1__5CD6CB2B");
        });

        modelBuilder.Entity<OrderRader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderRad__3214EC27B9EF25AC");

            entity.ToTable("OrderRader");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.KundId).HasColumnName("KundID");
            entity.Property(e => e.OrderDatum)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Kund).WithMany(p => p.OrderRaders)
                .HasForeignKey(d => d.KundId)
                .HasConstraintName("FK__OrderRade__KundI__5DCAEF64");
        });

        modelBuilder.Entity<Ordrar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ordrar__3214EC27502AD028");

            entity.ToTable("Ordrar");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.KundId).HasColumnName("KundID");
            entity.Property(e => e.OrderDatum)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Kund).WithMany(p => p.Ordrars)
                .HasForeignKey(d => d.KundId)
                .HasConstraintName("FK__Ordrar__KundID__5EBF139D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
