using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DL
{
    public partial class BRodriguezBulkCopyContext : DbContext
    {
        public BRodriguezBulkCopyContext()
        {
        }

        public BRodriguezBulkCopyContext(DbContextOptions<BRodriguezBulkCopyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DataTest> DataTests { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-6OBJBAUI; Database= BRodriguezBulkCopy; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DataTest>(entity =>
            {
                entity.HasKey(e => e.Profit)
                    .HasName("PK__DataTest__F0F889281B89EEAC");

                entity.ToTable("DataTest");

                entity.Property(e => e.Profit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PROFIT");

                entity.Property(e => e.Branch)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Deparment)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.HoldReason)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.JobOparator)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.JobProfit).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.JobRevRecog).HasColumnType("date");

                entity.Property(e => e.LocalClientName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Reason)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Rep)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Revenue).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Stat)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Wip).HasColumnName("WIP");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
