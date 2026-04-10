using _4gaDailyWorkReview.Server.DTOs;

namespace _4gaDailyWorkReview.Server.Repositories
{
    public interface IUserReadRepository
    {
        Task<UserDTO> GetUserByIdAsync(long id, CancellationToken ct);
    }
}
