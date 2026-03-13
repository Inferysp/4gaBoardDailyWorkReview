using _4gaDailyWorkReview.Server.DTOs;

namespace _4gaDailyWorkReview.Server.Repositories
{
    public interface IProjectReadRepository
    {
        Task<ProjectDTO?> GetByIdAsync(long id, CancellationToken ct);
        Task<List<ProjectDTO>> GetAllAsync(CancellationToken ct);
    }
}
