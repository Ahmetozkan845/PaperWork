using PaperWork.Api.Entitty;

namespace PaperWork.Api.Repositories
{
    public interface IPaperWorkRepository
    {
        Task<IEnumerable<PaperWorkEntity>> GetAllAsync(CancellationToken ct = default);
        Task<PaperWorkEntity?> GetByPwIdAsync(string pwId, CancellationToken ct = default);
        Task AddAsync(PaperWorkEntity entity, CancellationToken ct = default);
        Task UpdateAsync(PaperWorkEntity entity, CancellationToken ct = default);
        // İstenirse Delete de eklenebilir: Task DeleteAsync(string pwId, CancellationToken ct = default);
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
