using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TitanGate.Website.Domain.Entities;

namespace TitanGate.Website.DAL.Configurations
{
    /// <summary>
    /// Configurational class for <see cref="WebSite"/> entity.
    /// </summary>
    public class WebSiteEntityConfiguration : IEntityTypeConfiguration<WebSite>
    {
        public void Configure(EntityTypeBuilder<WebSite> builder)
        {
            builder.ToTable(nameof(WebSite));

            builder.HasKey(ws => ws.Id);

            builder.Property(ws => ws.Name)
                .IsRequired();

            builder.Property(ws => ws.URL)
                .IsRequired();

            builder.Property(ws => ws.HomepageSnapshot)
                .IsRequired();

            builder.Property(ws => ws.LoginId)
                .IsRequired();

            builder.Property(ws => ws.CategoryId)
                .IsRequired();

            builder
                .HasOne(ws => ws.Login)
                .WithMany(l => l.WebSites)
                .HasForeignKey(ws => ws.LoginId);

            builder
                .HasOne(ws => ws.Category)
                .WithMany(l => l.WebSites)
                .HasForeignKey(ws => ws.CategoryId);
        }
    }
}
