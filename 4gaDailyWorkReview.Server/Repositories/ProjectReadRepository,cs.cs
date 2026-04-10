using _4gaDailyWorkReview.Server.DTOs;
using _4gaDailyWorkReview.Server.Repositories.Interfaces;
using Dapper;
using System.Data;

namespace _4gaDailyWorkReview.Server.Repositories
{
    public class ProjectReadRepository : IProjectReadRepository
    {
        private readonly IDbConnection _db;

        public ProjectReadRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<ProjectDTO?> GetByIdAsync(long id, CancellationToken ct)
        {
            const string sql = @"
            SELECT name as Name,
                    background as Background,
                    created_at as CreatedAt,
                    updated_at as UpdatedAt,
                    background_image as BackgroundImage,
                    created_by_id as CreatedById,
                    updated_by_id as UpdatedById
            FROM Project
            WHERE Id = @Id";

            return await _db.QueryFirstOrDefaultAsync<ProjectDTO>(sql, new { Id = id });
        }

        public async Task<List<ProjectDTO>> GetAllAsync(CancellationToken ct)
        {
            const string sql = @"
            SELECT name as Name,
                    background as Background,
                    created_at as CreatedAt,
                    updated_at as UpdatedAt,
                    background_image as BackgroundImage,
                    created_by_id as CreatedById,
                    updated_by_id as UpdatedById
            FROM Project";

            var result = await _db.QueryAsync<ProjectDTO>(sql);
            return result.ToList();
        }
    }
}
