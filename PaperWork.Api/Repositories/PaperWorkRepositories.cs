using Microsoft.EntityFrameworkCore;
using PaperWork.Api.Data;
using PaperWork.Api.Entitty;

namespace PaperWork.Api.Repositories
{
    public class PaperWorkRepository : IPaperWorkRepository
    {
        private readonly PaperWorkDbContext _db;
        public PaperWorkRepository(PaperWorkDbContext db) => _db = db;

        public async Task<IEnumerable<PaperWorkEntity>> GetAllAsync(CancellationToken ct = default)
            => await _db.HrFeedbackProcesses.AsNoTracking().ToListAsync(ct);

        public async Task<PaperWorkEntity?> GetByPwIdAsync(string pwId, CancellationToken ct = default)
            => await _db.HrFeedbackProcesses.FirstOrDefaultAsync(x => x.PWId == pwId, ct);

        public async Task AddAsync(PaperWorkEntity entity, CancellationToken ct = default)
            => await _db.HrFeedbackProcesses.AddAsync(entity, ct);

        public Task UpdateAsync(PaperWorkEntity entity, CancellationToken ct = default)
        {
            _db.HrFeedbackProcesses.Update(entity);
            return Task.CompletedTask;
        }

        public Task<int> SaveChangesAsync(CancellationToken ct = default)
            => _db.SaveChangesAsync(ct);
    }
}
