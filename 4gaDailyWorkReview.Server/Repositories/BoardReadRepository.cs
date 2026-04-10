using _4gaDailyWorkReview.Server.DTOs;
using _4gaDailyWorkReview.Server.Repositories.Interfaces;
using Dapper;
using System.Data;

namespace _4gaDailyWorkReview.Server.Repositories
{
    public class BoardReadRepository : IBoardReadRepository
    {
        private readonly IDbConnection _db;

        public BoardReadRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<BoardDTO> GetByIdAsync(long id, CancellationToken ct)
        {
            const string sql = @"
            SELECT id as Id,
                    project_id as ProjectId,
                    name as Name,
                    github_repo as GithubRepo
            FROM Board
            WHERE Id = @Id";

            return await _db.QuerySingleOrDefaultAsync<BoardDTO>(sql, new { Id = id });
        }
    }
}
