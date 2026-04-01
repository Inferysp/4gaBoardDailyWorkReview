using _4gaDailyWorkReview.Server.DTOs;
using Dapper;
using System.Data;

namespace _4gaDailyWorkReview.Server.Repositories
{
    public class CardReadRepository : ICardReadRepository
    {
        private readonly IDbConnection _db;

        public CardReadRepository(IDbConnection db)
        {
            _db = db;
        }

        public async Task<CardDTO> GetCardByIdAsync(long id, CancellationToken ct)
        {
            const string sql = @"SELECT id as Id, 
                                        board_id as BoardId,
                                        list_id as ListId,
                                        created_by_id as CreatedById,
                                        cover_attachment_id as CoverAttachmentId,
                                        position as Position,
                                        name as Name,
                                        description as Description,
                                        due_date as DueDate,
                                        timer as Timer,
                                        created_at as CreatedAt,
                                        updated_at as UpdatedAt,
                                        comment_count as CommentCount,
                                        updated_by_id as UpdatedById
	                                FROM card
                                    WHERE Id = @Id;";
            return await _db.QueryFirstOrDefaultAsync<CardDTO>(sql, new { Id = id });

        }
    }
}
