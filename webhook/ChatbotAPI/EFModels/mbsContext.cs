using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChatbotAPI.EFModels
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
        public virtual DbSet<PostcodesGeo> PostcodesGeo { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=xx.xx.xx.xx;port=3306;user=root;password=******;database=mbs");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OshcQuote>(entity =>
            {
                entity.ToTable("OshcQuote", "mbs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Ahm).HasColumnType("decimal(16,2)");

                entity.Property(e => e.Allianz).HasColumnType("decimal(16,2)");

                entity.Property(e => e.Bupa).HasColumnType("decimal(16,2)");

                entity.Property(e => e.Cbhs)
                    .HasColumnName("cbhs")
                    .HasColumnType("decimal(16,2)");

                entity.Property(e => e.Covertype)
                    .HasColumnName("covertype")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Duration).HasColumnType("int(11)");

                entity.Property(e => e.Medibank).HasColumnType("decimal(16,2)");

                entity.Property(e => e.Nib).HasColumnType("decimal(16,2)");
            });

            modelBuilder.Entity<PostcodesGeo>(entity =>
            {
                entity.ToTable("postcodes_geo", "mbs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("decimal(6,3)");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("decimal(6,3)");

                entity.Property(e => e.Postcode)
                    .HasColumnName("postcode")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Suburb)
                    .HasColumnName("suburb")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.ItemNum);

                entity.ToTable("schedule", "mbs");

                entity.HasIndex(e => e.ItemNum)
                    .HasName("ItemNum_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.ItemNum)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Anaes)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.AnaesChange)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.BasicUnits)
                    .HasColumnName("Basic Units")
                    .HasColumnType("decimal(6,2)");

                entity.Property(e => e.Benefit100).HasColumnType("decimal(6,2)");

                entity.Property(e => e.Benefit75).HasColumnType("decimal(6,2)");

                entity.Property(e => e.Benefit85).HasColumnType("decimal(6,2)");

                entity.Property(e => e.BenefitStartDate).HasColumnType("date");

                entity.Property(e => e.BenefitType)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DerivedFee).HasColumnType("longtext");

                entity.Property(e => e.DerivedFeeStartDate).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnType("longtext");

                entity.Property(e => e.DescriptionStartDate).HasColumnType("date");

                entity.Property(e => e.DescriptorChange)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Emsncap)
                    .HasColumnName("EMSNCap")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Emsnchange)
                    .HasColumnName("EMSNChange")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.EmsnchangeDate)
                    .HasColumnName("EMSNChangeDate")
                    .HasColumnType("date");

                entity.Property(e => e.Emsndescription)
                    .HasColumnName("EMSNDescription")
                    .HasColumnType("longtext");

                entity.Property(e => e.EmsnendDate)
                    .HasColumnName("EMSNEndDate")
                    .HasColumnType("date");

                entity.Property(e => e.EmsnfixedCapAmount)
                    .HasColumnName("EMSNFixedCapAmount")
                    .HasColumnType("decimal(7,2)");

                entity.Property(e => e.EmsnmaximumCap)
                    .HasColumnName("EMSNMaximumCap")
                    .HasColumnType("decimal(7,2)");

                entity.Property(e => e.EmsnpercentageCap)
                    .HasColumnName("EMSNPercentageCap")
                    .HasColumnType("decimal(7,2)");

                entity.Property(e => e.EmsnstartDate)
                    .HasColumnName("EMSNStartDate")
                    .HasColumnType("date");

                entity.Property(e => e.FeeChange)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.FeeStartDate).HasColumnType("date");

                entity.Property(e => e.FeeType)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Group)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ItemChange)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ItemEndDate).HasColumnType("date");

                entity.Property(e => e.ItemStartDate).HasColumnType("date");

                entity.Property(e => e.ItemType)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.NewItem)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ProviderType)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.QfeendDate)
                    .HasColumnName("QFEEndDate")
                    .HasColumnType("date");

                entity.Property(e => e.QfestartDate)
                    .HasColumnName("QFEStartDate")
                    .HasColumnType("date");

                entity.Property(e => e.ScheduleFee).HasColumnType("decimal(6,2)");

                entity.Property(e => e.SubGroup)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SubHeading)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SubItemNum)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });
        }
    }
}
