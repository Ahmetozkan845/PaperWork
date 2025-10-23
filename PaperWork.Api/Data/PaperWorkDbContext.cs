using Microsoft.EntityFrameworkCore;
using PaperWork.Api.Entitty;

namespace PaperWork.Api.Data
{
    public class PaperWorkDbContext : DbContext
    {
        public PaperWorkDbContext(DbContextOptions<PaperWorkDbContext> options) : base(options) { }

        public DbSet<PaperWorkEntity> HrFeedbackProcesses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var e = modelBuilder.Entity<PaperWorkEntity>();
            e.HasKey(x => x.PWId);
        }
    }
}
