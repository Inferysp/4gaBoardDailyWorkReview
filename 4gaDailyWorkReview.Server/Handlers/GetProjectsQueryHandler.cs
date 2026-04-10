using _4gaDailyWorkReview.Server.Data;
using _4gaDailyWorkReview.Server.DTOs;
using _4gaDailyWorkReview.Server.Models;
using _4gaDailyWorkReview.Server.Queries;
using _4gaDailyWorkReview.Server.Repositories.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace _4gaDailyWorkReview.Server.Handlers
{
    public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, List<ProjectDTO>>
    {
        private readonly IProjectReadRepository _repo;

        public GetProjectsQueryHandler(IProjectReadRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ProjectDTO>> Handle(GetProjectsQuery request, CancellationToken ct)
        {
            return await _repo.GetAllAsync(ct);
            //return await _ctx.Projects.Select(p => new ProjectDTO
            //{
            //    Name = p.Name,
            //    Background = p.Background,
            //    CreatedAt = p.CreatedAt,
            //    UpdatedAt = p.UpdatedAt,
            //    BackgroundImage = p.BackgroundImage
            //    //CreatedById = p.Created
            //}).ToListAsync(ct);
        }
    }
}
