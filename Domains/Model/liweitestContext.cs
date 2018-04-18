using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domains.Model
{
    public partial class liweitestContext : DbContext
    {
        public virtual DbSet<TestTableEntity> TestTable { get; set; }
        public virtual DbSet<TestTable2> TestTable2 { get; set; }

        public liweitestContext(DbContextOptions<liweitestContext> options)
       : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestTableEntity>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Sex).HasColumnName("sex");
            });

            modelBuilder.Entity<TestTable2>(entity =>
            {
                entity.ToTable("testTable2");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Memo)
                    .HasColumnName("memo")
                    .HasColumnType("text");

                entity.Property(e => e.Memo2)
                    .HasColumnName("memo2")
                    .HasColumnType("text");

                entity.Property(e => e.TestTableId).HasColumnName("TestTableID");
            });
        }
    }
}
