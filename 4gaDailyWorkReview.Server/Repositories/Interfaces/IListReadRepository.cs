using _4gaDailyWorkReview.Server.DTOs;

namespace _4gaDailyWorkReview.Server.Repositories.Interfaces
{
    public interface IListReadRepository
    {
        Task<ListDTO> GetListByIdAsync(long id, CancellationToken ct);
    }
}
