using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Entities
{
    public partial class ArcadisExamContext : DbContext
    {
        public ArcadisExamContext()
        {
        }

        public ArcadisExamContext(DbContextOptions<ArcadisExamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ExampleWorkSheet> ExampleWorkSheet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=LAPTOP-SPAAL3BP;Database=ArcadisExam;Integrated Security=True");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExampleWorkSheet>(entity =>
            {
                entity.ToTable("exampleWorkSheet");

                entity.Property(e => e.Cost).HasColumnType("numeric(10, 4)");

                entity.Property(e => e.CostInd)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TotalCost)
                    .HasColumnType("numeric(21, 4)")
                    .HasComputedColumnSql("([Cost]*[Quantity])");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
