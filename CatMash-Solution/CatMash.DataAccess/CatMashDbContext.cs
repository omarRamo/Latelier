using CatMash.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatMash.DataAccess
{
    public partial class CatMashDbContext: DbContext
    {
        public CatMashDbContext()
        {
        }

        public CatMashDbContext(DbContextOptions<CatMashDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<TCatPicture> TCatPicture { get; set; }
        public virtual DbSet<TVote> TVote { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TCatPicture>().ToTable("T_CatPicture", t => t.ExcludeFromMigrations());

            modelBuilder.Entity<TCatPicture>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("T_CatPicture");

                entity.Property(e => e.Url).IsRequired();
            });

            modelBuilder.Entity<TVote>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("T_Vote");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.TVoteWinCat)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vote_WinCat_CatId");

            });
        }

    }
}
