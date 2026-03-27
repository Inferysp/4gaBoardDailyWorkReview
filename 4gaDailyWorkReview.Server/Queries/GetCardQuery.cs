using _4gaDailyWorkReview.Server.DTOs;
using MediatR;

namespace _4gaDailyWorkReview.Server.Queries
{
    public record GetCardQuery(long id) : IRequest<CardDTO>;
}

