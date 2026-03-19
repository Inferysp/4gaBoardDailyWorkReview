using _4gaDailyWorkReview.Server.DTOs;
using _4gaDailyWorkReview.Server.Queries;
using _4gaDailyWorkReview.Server.Repositories;
using MediatR;

namespace _4gaDailyWorkReview.Server.Handlers
{
    public class GetBoardQueryHandler : IRequestHandler<GetBoardQuery, BoardDTO>
    {
        private readonly IBoardReadRepository _repo;

        public GetBoardQueryHandler(IBoardReadRepository repo)
        {
            _repo = repo;
        }

        public async Task<BoardDTO> Handle(GetBoardQuery request, CancellationToken ct)
        {
            return await _repo.GetByIdAsync(request.Id, ct);

        }
    }
}
