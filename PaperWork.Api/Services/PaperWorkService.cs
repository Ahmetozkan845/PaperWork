using PaperWork.Api.Entitty;
using PaperWork.Api.Repositories;

namespace PaperWork.Api.Services
{
    public class PaperWorkService : IPaperWorkService
    {
        private readonly IPaperWorkRepository _repo;
        public PaperWorkService(IPaperWorkRepository repo) => _repo = repo;

        public Task<IEnumerable<PaperWorkEntity>> ListAsync(CancellationToken ct = default)
            => _repo.GetAllAsync(ct);

        public Task<PaperWorkEntity?> GetAsync(string pwId, CancellationToken ct = default)
            => _repo.GetByPwIdAsync(pwId, ct);

        public async Task<(bool ok, string? error, PaperWorkEntity? created)> CreateAsync(PaperWorkEntity dto, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(dto.PWId))
                return (false, "PWId is required.", null);

            // Çakışma kontrolü
            var exists = await _repo.GetByPwIdAsync(dto.PWId, ct);
            if (exists is not null)
                return (false, $"PWId already exists: {dto.PWId}", null);

            await _repo.AddAsync(dto, ct);
            await _repo.SaveChangesAsync(ct);
            return (true, null, dto);
        }

        public async Task<(bool ok, string? error, PaperWorkEntity? updated)> UpdateAsync(string pwId, PaperWorkEntity dto, CancellationToken ct = default)
        {
            var entity = await _repo.GetByPwIdAsync(pwId, ct);
            if (entity is null)
                return (false, $"Not found: {pwId}", null);

            // PK değişmez. Diğer alanları setle
            entity.Year = dto.Year;
            entity.Month = dto.Month;
            entity.FeedbackType = dto.FeedbackType;
            entity.ActionDecision = dto.ActionDecision;
            entity.Directorate = dto.Directorate;
            entity.Department = dto.Department;
            entity.EmployeeName = dto.EmployeeName;
            entity.EmployeeRegistrationNumber = dto.EmployeeRegistrationNumber;
            entity.CBACodes = dto.CBACodes;
            entity.FeedbackChannel = dto.FeedbackChannel;
            entity.ActionOwnerManager = dto.ActionOwnerManager;
            entity.ActionOwnerManagerRegistrationNumber = dto.ActionOwnerManagerRegistrationNumber;
            entity.FeedbackDetail = dto.FeedbackDetail;
            entity.ActionOwnerManagerFeedbackDetail = dto.ActionOwnerManagerFeedbackDetail;
            entity.GettingStartedGeneralDescription = dto.GettingStartedGeneralDescription;
            entity.CreateUser = dto.CreateUser;
            entity.CreateDate = dto.CreateDate;
            entity.IsActive = dto.IsActive;

            await _repo.UpdateAsync(entity, ct);
            await _repo.SaveChangesAsync(ct);
            return (true, null, entity);
        }
    }
}
