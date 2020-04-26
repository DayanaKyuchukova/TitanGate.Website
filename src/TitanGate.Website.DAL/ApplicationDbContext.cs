using Microsoft.EntityFrameworkCore;
using TitanGate.Website.DAL.Configurations;
using TitanGate.Website.Domain.Entities;

namespace TitanGate.Website.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options) { }

        public DbSet<Login> Login { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<WebSite> Website { get; set; }

        #region Protected Methods

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new LoginEntityConfiguration())
                .ApplyConfiguration(new CategoryEntityConfiguration())
                .ApplyConfiguration(new WebSiteEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
