using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TitanGate.Website.Domain.Entities;

namespace TitanGate.Website.DAL.Configurations
{
    /// <summary>
    /// Configurational class for <see cref="Login"/> entity.
    /// </summary>
    public class LoginEntityConfiguration : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.ToTable(nameof(Login));

            builder.HasKey(l => l.Id);

            builder.HasData(new Login[] { new Login { Id = 1, Email = "dayanakyuchukova@gmail.com", Password = "1234"} });
        }
    }
}
