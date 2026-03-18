using _4gaDailyWorkReview.Server.DTOs;

namespace _4gaDailyWorkReview.Server.Repositories
{
    public interface IBoardReadRepository
    {
        Task<BoardDTO> GetByIdAsync(long id, CancellationToken ct);
    }
}
