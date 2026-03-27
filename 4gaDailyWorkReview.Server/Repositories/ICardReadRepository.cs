using _4gaDailyWorkReview.Server.DTOs;
using System.Data;

namespace _4gaDailyWorkReview.Server.Repositories
{
    public interface ICardReadRepository
    {
        Task<CardDTO> GetCardByIdAsync(long id, CancellationToken ct);
    }
}