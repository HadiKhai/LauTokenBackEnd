using System;
using System.Collections.Generic;
using LauToken.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LauToken.Repository
{
    public partial class postgresContext : DbContext
    {
        public postgresContext()
        {
            
        }

        public postgresContext(DbContextOptions<postgresContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Store> Stores { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=lautokenpg.postgres.database.azure.com;Database=postgres;Username=postgres;Password=postgres;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("azure")
                .HasPostgresExtension("pg_cron");

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.Address)
                    .HasName("store_pkey");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Date).HasDefaultValueSql("now()");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}