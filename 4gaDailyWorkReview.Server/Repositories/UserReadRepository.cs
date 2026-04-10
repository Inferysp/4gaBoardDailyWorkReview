using _4gaDailyWorkReview.Server.DTOs;
using _4gaDailyWorkReview.Server.Models;
using _4gaDailyWorkReview.Server.Repositories.Interfaces;
using Dapper;
using System.Data;

namespace _4gaDailyWorkReview.Server.Repositories
{
    public class UserReadRepository : IUserReadRepository
    {
        private readonly IDbConnection _dbConn;

        public UserReadRepository(IDbConnection dbConn)
        {
            _dbConn = dbConn;
        }

        public async Task<UserDTO> GetUserByIdAsync(long Id, CancellationToken ct)
        {
            var sql = "SELECT id as Id, name as Name FROM user_account WHERE Id = @Id";

            return await _dbConn.QueryFirstAsync<UserDTO>(sql, new { Id = Id});
        }
    }
}
