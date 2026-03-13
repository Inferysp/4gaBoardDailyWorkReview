using _4gaDailyWorkReview.Server.DTOs;
using MediatR;

namespace _4gaDailyWorkReview.Server.Queries
{
    public record GetProjectsQuery() : IRequest<List<ProjectDTO>>;
}
