using _4gaDailyWorkReview.Server.DTOs;
using Dapper;
using System.Data;

namespace _4gaDailyWorkReview.Server.Repositories
{
    public class ListReadRepository : IListReadRepository
    {
        private readonly IDbConnection _db;

        public ListReadRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<ListDTO> GetListByIdAsync(long id, CancellationToken ct)
        {

            const string sql = @"SELECT id as Id, 
                                name as Name
                        FROM list
                        WHERE Id = @Id";

            return await _db.QueryFirstAsync<ListDTO>(sql, new { Id = id });
        }
    }
}
