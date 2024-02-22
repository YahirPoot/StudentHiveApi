using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentHive.Domain.Entities;

namespace StudentHiveApi.Infrastructure.Data.Configurations;

public class ReportConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {
        builder.ToTable("Reports");
        builder.HasKey(e => e.IdReport).HasName("PK__Reports__C6245294BFC7444A");

            builder.Property(e => e.IdReport).HasColumnName("ID_Report");
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.IdReportType).HasColumnName("ID_ReportType");

            builder.HasOne(d => d.IdReportTypeNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => d.IdReportType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reports__ID_Repo__693CA210");

            builder.HasMany(d => d.IdPublication).WithMany(p => p.IdReport)
                .UsingEntity<Dictionary<string, object>>(
                    "PublicationReports",
                    r => r.HasOne<RentalHouse>().WithMany()
                        .HasForeignKey("IdPublication")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Publicati__ID_Pu__72C60C4A"),
                    l => l.HasOne<Report>().WithMany()
                        .HasForeignKey("IdReport")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Publicati__ID_Re__71D1E811"),
                    j =>
                    {
                        j.HasKey("IdReport", "IdPublication").HasName("PK__Publicat__6B6B3337EA369791");
                        j.IndexerProperty<int>("IdReport").HasColumnName("ID_Report");
                        j.IndexerProperty<int>("IdPublication").HasColumnName("ID_Publication");
                    });

            builder.HasMany(d => d.IdUser).WithMany(p => p.IdReport)
                .UsingEntity<Dictionary<string, object>>(
                    "UserReports",
                    r => r.HasOne<User>().WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserRepor__ID_Us__6D0D32F4"),
                    l => l.HasOne<Report>().WithMany()
                        .HasForeignKey("IdReport")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserRepor__ID_Re__6C190EBB"),
                    j =>
                    {
                        j.HasKey("IdReport", "IdUser").HasName("PK__UserRepo__F8F08CD01275610A");
                        j.IndexerProperty<int>("IdReport").HasColumnName("ID_Report");
                        j.IndexerProperty<int>("IdUser").HasColumnName("ID_User");
                    });
    }
}