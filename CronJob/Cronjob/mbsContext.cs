using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Cronjob
{
    public partial class mbsContext : DbContext
    {
        public mbsContext()
        {
        }

        public mbsContext(DbContextOptions<mbsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OshcQuote> OshcQuote { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=xx.xx.xx.xx;port=3306;user=root;password=*******;database=mbs");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<OshcQuote>(entity =>
            {
                entity.ToTable("OshcQuote", "mbs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Ahm).HasColumnType("decimal(6,2)");

                entity.Property(e => e.Allianz).HasColumnType("decimal(6,2)");

                entity.Property(e => e.Bupa).HasColumnType("decimal(6,2)");

                entity.Property(e => e.Cbhs)
                    .HasColumnName("cbhs")
                    .HasColumnType("decimal(6,2)");

                entity.Property(e => e.Covertype)
                    .HasColumnName("covertype")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Duration).HasColumnType("int(11)");

                entity.Property(e => e.Medibank).HasColumnType("decimal(6,2)");

                entity.Property(e => e.Nib).HasColumnType("decimal(6,2)");
            });
        }
    }
}
