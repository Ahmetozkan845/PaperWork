using PaperWork.Api.Entitty;

namespace PaperWork.Api.Services
{
    public interface IPaperWorkService
    {
        Task<IEnumerable<PaperWorkEntity>> ListAsync(CancellationToken ct = default);
        Task<PaperWorkEntity?> GetAsync(string pwId, CancellationToken ct = default);
        Task<(bool ok, string? error, PaperWorkEntity? created)> CreateAsync(PaperWorkEntity dto, CancellationToken ct = default);
        Task<(bool ok, string? error, PaperWorkEntity? updated)> UpdateAsync(string pwId, PaperWorkEntity dto, CancellationToken ct = default);
        // İstenirse DeleteAsync eklenir
    }
}
