using _4gaDailyWorkReview.Server.Data;
using _4gaDailyWorkReview.Server.DTOs;
using _4gaDailyWorkReview.Server.Queries;
using _4gaDailyWorkReview.Server.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace _4gaDailyWorkReview.Server.Handlers
{
    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ProjectDTO>
    {
        private readonly IProjectReadRepository _repo;

        public GetProjectQueryHandler(IProjectReadRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProjectDTO> Handle(GetProjectQuery request, CancellationToken ct)
        {
            return await _repo.GetByIdAsync(request.Id, ct);
        }
    }
}
